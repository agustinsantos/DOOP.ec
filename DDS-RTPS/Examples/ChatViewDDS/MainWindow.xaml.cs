using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DDS.ConversionUtils;
using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using org.omg.dds.core.status;
using org.omg.dds.domain;
using org.omg.dds.pub;
using org.omg.dds.sub;
using org.omg.dds.sub.modifiable;
using org.omg.dds.topic;
using System.ComponentModel;

namespace ChatViewDDS
{

    

    #region Service Interfaces
    public class ChatMessage
    {
        private readonly string values;

        public ChatMessage(string values)
        {
            this.values = values;
        }

        public string Values
        {
            get { return this.values; }
        }

        public override string ToString()
        {
            return this.values;
        }
    }


    public class MyListener : DataReaderAdapter<ChatMessage>
    {
        public BackgroundWorker backgroundWorker1;

        public MyListener(BackgroundWorker backgroundWorker){
            this.backgroundWorker1 = backgroundWorker;
        }

        /// <summary>
        /// Method is called when a new message arrives from the Publisher
        /// </summary>
        /// <param name="status">get data avaliable</param>
        public override void OnDataAvailable(DataAvailableStatus<ChatMessage> status)
        {
            // Obtain the source of DataReader 
            DataReader<ChatMessage> dr = status.GetSource();
            // Obtain the stack of messages published
            SampleIterator<ChatMessage> it = dr.Take();
            // Iterator of the list of messages, to present it in console
            foreach (Sample<ChatMessage> smp in it)
            {
                // SampleInfo stuff is built into Sample:
                // InstanceHandle inst = smp.GetInstanceHandle();
                // Data accessible from Sample; null if invalid:
                ChatMessage dt = smp.GetData();
                this.backgroundWorker1.RunWorkerAsync(dt);
            }
            
        }
    }
    #endregion
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        #region Instance Fields
        protected static int domainId = -1;
        public DataWriter<ChatMessage> dw;
        public DomainParticipantFactory factory;
        public DomainParticipant dp;
        public Topic<ChatMessage> tp;
        public Subscriber sub;
        public DataReaderListener<ChatMessage> ls;
        public DataReader<ChatMessage> dr;
        public Publisher pub;
        public BackgroundWorker backgroundWorker1;
        #endregion

        #region Window Methods
        public MainWindow()
        {
            InitializeComponent();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Closing += new System.ComponentModel.CancelEventHandler(WindowMain_Closing);
            this.txtMemberName.Focus();
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
        }

        void WindowMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            dp.Close();
        }
        #endregion

        #region Button Click Handlers
        private void btnConnect_click(object sender, RoutedEventArgs e)
        {
            string id = this.txtMemberName.Text;
            int.TryParse(id, out domainId);
            factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            dp = factory.CreateParticipant(domainId);
            
            tp = dp.CreateTopic<ChatMessage>("Greetings Topic");
          
            sub = dp.CreateSubscriber();
            ls = new MyListener(backgroundWorker1);
            dr = sub.CreateDataReader<ChatMessage>(tp, sub.GetDefaultDataReaderQos(), ls, null);
            pub = dp.CreatePublisher();
            dw = pub.CreateDataWriter(tp);
            if (dw != null)
            {
                this.grdLogin.Visibility = Visibility.Collapsed;
                this.grdChat.Visibility = Visibility.Visible;
            }
        }

        private void btnChat_Click(object sender, RoutedEventArgs e)
        {
            String msg = this.txtChatMsg.Text;
            ChatMessage data = new ChatMessage(msg);
            dw.Write(data);
            this.lstChatMsgs.Items.Add("Sending data \"{" + this.txtMemberName.Text + "}\": " + data.Values);
            this.txtChatMsg.Text = "";
            this.txtChatMsg.Focus();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ChatMessage msg = e.Argument as ChatMessage;
            e.Result = msg;
        }

        private void backgroundWorker1_RunWorkerCompleted( object sender,RunWorkerCompletedEventArgs e)
        {
            ChatMessage msg = e.Result as ChatMessage;
            if (msg != null && msg.Values != null)
            {
                this.lstChatMsgs.Items.Add("Received data: " + msg.Values);
            }
        }
        #endregion
    }
}

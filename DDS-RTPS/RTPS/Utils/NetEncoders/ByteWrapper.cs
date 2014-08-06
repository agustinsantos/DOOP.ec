﻿using System;

namespace Sxta.GenericProtocol.Encoding
{
    /// <summary>
    /// Utility class for managing data in byte arrays.
    /// </summary>
    public class ByteWrapper
    {

        private static readonly byte[] ZERO_LENGTH_BUFFER = new byte[0];

        /// <summary>
        /// Offset for the start position in the buffer.
        /// </summary>
        private int _offset;


        /// <summary>
        /// The current postion (or index) in the buffer.
        /// </summary>
        private int _pos;


        /// <summary>
        /// The length of the buffer. 
        /// </summary>
        private int _limit;


        /// <summary>
        /// The backing byte array.
        /// </summary>
        private byte[] _buffer;
        public static readonly bool IsLittleEndian = BitConverter.IsLittleEndian;

        /// <summary>
        /// Construct a ByteWrapper backed by a zero-length byte array.
        /// </summary>
        public ByteWrapper()
            : this(ZERO_LENGTH_BUFFER)
        {
        }

        /// <summary>
        /// Construct a ByteWrapper backed by a byte array with the specified <code>length</code>.
        /// </summary>
        /// <param name='length'>
        /// length of the backing byte array
        /// </param>
        public ByteWrapper(int length)
            : this(new byte[length])
        {
        }

        /// <summary>
        /// Constructs a <code>ByteWrapper</code> backed by the specified byte array. (Changes to
        /// the ByteWrapper will write through to the specified byte array.)
        /// </summary>
        /// <param name='buffer'>
        /// backing byte array
        /// </param>
        public ByteWrapper(byte[] buffer)
            : this(buffer, 0, buffer.Length)
        {
        }

        /// <summary>
        /// Constructs a <code>ByteWrapper</code> backed by the specified byte array. (Changes to
        /// the ByteWrapper will write through to the specified byte array.)
        /// The <code>offset</code> will be at the start position. Limit will be at <code>buffer.length</code>.
        /// </summary>
        /// <param name='buffer'>
        /// backing byte array
        /// </param>
        /// <param name='offset'>
        /// start position offset
        /// </param>
        public ByteWrapper(byte[] buffer, int offset)
            : this(buffer, offset, buffer.Length - offset)
        {
        }

        /// <summary>
        /// Constructs a <code>ByteWrapper</code> backed by the specified byte array. (Changes to
        /// the ByteWrapper will write through to the specified byte array.)
        /// </summary>
        /// <param name='buffer'>
        /// backing byte array.
        /// </param>
        /// <param name='offset'>
        /// start position offset.
        /// </param>
        /// <param name='length'>
        /// length of the segment to use.
        /// </param>
        public ByteWrapper(byte[] buffer, int offset, int length)
        {
            SetBuffer(buffer, offset, length);
        }

        /// <summary>
        /// Changes the backing store used by this ByteWrapper. Changes to the
        /// ByteWrapper will write through to the specified byte array.
        /// </summary>
        /// <param name='buffer'>
        /// backing byte array.
        /// </param>
        /// <param name='offset'>
        /// start position offset.
        /// </param>
        /// <param name='length'>
        /// length of the segment to use.
        /// </param>
        public void Reassign(byte[] buffer, int offset, int length)
        {
            SetBuffer(buffer, offset, length);
        }

        private void SetBuffer(byte[] buffer, int offset, int length)
        {
            CheckBounds(buffer, offset, length);
            _buffer = buffer;
            _offset = offset;
            _limit = _offset + length;
            _pos = _offset;
        }

        private void CheckBounds(byte[] buffer, int offset, int length)
        {
            if (offset < 0)
            {
                throw new IndexOutOfRangeException("Negative offset: " + offset);
            }
            if (length < 0 || offset + length > buffer.Length)
            {
                throw new IndexOutOfRangeException("Offset + length (" + offset + " + " + length + ") past end of buffer: " + buffer.Length);
            }
        }

        /// <summary>
        /// Resets current position to the start of the ByteWrapper.
        /// </summary>
        public virtual void Reset()
        {
            _pos = _offset;
        }


        /// <summary>
        /// Verify that <code>length</code> bytes can be read.
        /// </summary>
        /// <param name='length'>
        /// number of byte to verify.
        /// </param>
        /// <exception cref='IndexOutOfRangeException'>
        /// if <code>length</code> bytes can not be read.
        /// </exception>
        public virtual void Verify(int length)
        {
            if (length < 0)
            {
                throw new IndexOutOfRangeException("length = " + length);
            }
            if (_pos + length > _limit)
            {
                throw new IndexOutOfRangeException("_pos + length = " + (_pos + length));
            }
        }

        /// <summary>
        /// Reads the next byte of the ByteWrapper. The current position is increased by 1.
        /// </summary>
        /// <returns>
        /// decoded value
        /// </returns>
        /// <exception cref='IndexOutOfRangeException'>
        /// if <code>length</code> bytes can not be read.
        /// </exception
        public byte GetByte()
        {
            Verify(1);
            return _buffer[_pos++];
        }

        /// <summary>
        /// Reads <code>dest.length</code> bytes from the ByteWrapper into <code>dest</code>. The
        /// current position is increased by <code>dest.length</code>.
        /// </summary>
        /// <param name='dest'>
        /// destination for the read bytes
        /// </param>
        /// <exception cref='IndexOutOfRangeException'>
        /// if <code>length</code> bytes can not be read.
        /// </exception
        public void GetBytes(byte[] dest)
        {
            Verify(dest.Length);
            Array.Copy(_buffer, _pos, dest, 0, dest.Length);
            _pos += dest.Length;
        }
        public byte[] GetBytes(int len)
        {
            byte[] dest = new byte[len];
            Array.Copy(_buffer, _pos, dest, 0, dest.Length);
            _pos += dest.Length;
            return dest;
        }

        /// <summary>
        /// Writes <code>byte</code> to the ByteWrapper and advances the current position by 1
        /// </summary>
        /// <param name="b">byte to write</param>
        public virtual void Put(byte b)
        {
            Verify(1);
            _buffer[_pos++] = (byte)b;
        }

        /// <summary>
        /// Writes a byte array to the ByteWrapper and advances the current
        /// posisiton by the size of the byte array.
        /// </summary>
        /// <param name="src">byte array to write</param>
        public virtual void Put(byte[] src)
        {
            Verify(src.Length);
            Array.Copy(src, 0, _buffer, _pos, src.Length);
            _pos += src.Length;
        }


        /// <summary>
        /// Writes a subset of a byte array to the ByteWrapper and advances the current
        /// posisiton by the size of the subset.
        /// </summary>
        /// <param name='src'>
        /// byte array to write.
        /// </param>
        /// <param name='offset'>
        /// offset of subset to write.
        /// </param>
        /// <param name='count'>
        /// size of offset to write.
        /// </param>
        /// <exception cref="IndexOutOfRangeException">
        /// if the bytes can not be written
        /// </exception>
        public virtual void Put(byte[] src, int offset, int count)
        {
            Verify(count);
            Array.Copy(src, offset, _buffer, _pos, count);
            _pos += count;
        }

        /// <summary>
        /// Returns the backing array.
        /// </summary>
        /// <returns>
        /// the backing byte array
        /// </returns>
        public byte[] Buffer
        {
            get
            {
                return _buffer;
            }
        }

        /// <summary>
        /// Returns the current position.
        /// </summary>
        /// <returns>
        /// the current potition within the byte array
        /// </returns>
        public int Position
        {
            get
            {
                return _pos;
            }
        }
        /// <summary>
        /// Returns the number of remaining bytes in the byte array.
        /// </summary>
        /// <returns>
        /// the number of remaining bytes in the byte array
        /// </returns>
        public int Remaining
        {
            get
            {
                return _limit - _pos;
            }
        }

        /// <summary>
        /// Advances the current position by <code>n</code>.
        /// </summary>
        /// <param name='n'>
        /// number of positions to advance
        /// </param>
        /// <exception cref="IndexOutOfRangeException">
        /// if the position can not be advanced
        /// </exception>
        public void Advance(int n)
        {
            Verify(n);
            _pos += n;
        }


        /// <summary>
        /// Advances the current position until the specified <code>alignment</code> is
        /// achieved.
        /// </summary>
        /// <param name='alignment'>
        /// alignment that the current position must support
        /// </param>
        public void Align(int alignment)
        {
            while (((_pos - _offset) % alignment) != 0)
            {
                Advance(1);
            }
        }

        /// <summary>
        /// Slice this instance.
        /// </summary>
        /// <returns>
        /// a new <code>ByteWrapper</code> backed by the same byte array starting at the current position
        /// </returns>
        public ByteWrapper Slice()
        {
            return new ByteWrapper(_buffer, _pos);
        }

        /// <summary>
        /// reates a <code>ByteWrapper</code> backed by the same byte array using the current
        /// position as its offset, and the specified <code>length</code> to mark the limit.
        /// </summary>
        /// <param name='length'>
        /// length of the new <code>ByteWrapper</code>
        /// </param>
        /// <returns>
        /// a new <code>ByteWrapper</code> backed by the same byte array starting at the current position
        /// with the defined <code>length</code>
        /// </returns>
        /// <exception cref="IndexOutOfRangeException">
        /// if the <code>length</code> is to long
        /// </exception>
        public ByteWrapper Slice(int length)
        {
            Verify(length);
            return new ByteWrapper(_buffer, _pos, length);
        }


        /// <summary>
        /// Returns a string representation of the ByteWrapper.
        /// </summary>
        /// <returns>
        /// a string representation of the ByteWrapper
        /// </returns>
        public override string ToString()
        {
            return "ByteWrapper{_offset=" + _offset + ", _pos=" + _pos + ", _limit=" + _limit + ", _buffer=" + _buffer + "}";
        }

        public static byte[] ReverseBytes(byte[] inArray)
        {
            byte temp;
            int highCtr = inArray.Length - 1;

            for (int ctr = 0; ctr < inArray.Length / 2; ctr++)
            {
                temp = inArray[ctr];
                inArray[ctr] = inArray[highCtr];
                inArray[highCtr] = temp;
                highCtr -= 1;
            }
            return inArray;
        }
    }

}

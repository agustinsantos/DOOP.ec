/* Copyright 2010, Object Management Group, Inc.
 * Copyright 2010, PrismTech, Inc.
 * Copyright 2010, Real-Time Innovations, Inc.
 * All rights reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */


using System.Collections.Generic;

namespace org.omg.dds.topic
{

    /// <summary>
    /// ContentFilteredTopic is a specialization of TopicDescription that allows
    /// for content-based subscriptions
    /// 
    /// ContentFilteredTopic describes a more sophisticated subscription that
    /// indicates the subscriber does not want to necessarily see all values of
    /// each instance published under the {@link Topic}. Rather, it wants to see
    /// only the values whose contents satisfy certain criteria. This class
    /// therefore can be used to request content-based subscriptions
    /// 
    /// The selection of the content is done using the filterExpression with
    /// parameters expressionParameters.
    /// <ul>
    /// <li>The filterExpression attribute is a string that specifies the criteria
    /// to select the data samples of interest. It is similar to the WHERE
    /// part of an SQL clause.</li>
    /// <li>The expressionParameters attribute is a sequence of strings that give
    /// values to the "parameters" (i.e., "%n" tokens) in the filterExpression.
    /// The number of supplied parameters must fit with the requested values
    /// in the filterExpression (i.e., the number of "%n" tokens).</li>
    /// </ul>
    /// </summary>
    /// <typeparam name="TYPE">The concrete type of the data that will be published and/
    ///                        or subscribed by the readers and writers that use this
    ///                        topic description
    /// </typeparam>
    public interface ContentFilteredTopic<TYPE> : TopicDescription<TYPE>
    {
        string GetFilterExpression();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>An unmodifiable list</returns>
        List<string> GetExpressionParameters();

        void SetExpressionParameters(List<string> expressionParameters);

        Topic<T> GetRelatedTopic<T>() where T : TYPE;
    }
}
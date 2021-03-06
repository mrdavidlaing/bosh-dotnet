﻿// -----------------------------------------------------------------------
// <copyright file="LoadSettingsException.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Uhuru.BOSH.Agent.Errors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Load Settings BOSH exception.
    /// </summary>
    [Serializable]
    public class LoadSettingsException : BoshException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoadSettingsException"/> class.
        /// </summary>
        public LoadSettingsException() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="LoadSettingsException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public LoadSettingsException(string message) : base(message) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="LoadSettingsException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public LoadSettingsException(string message, Exception inner) : base(message, inner) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="LoadSettingsException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
        ///   
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        protected LoadSettingsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}

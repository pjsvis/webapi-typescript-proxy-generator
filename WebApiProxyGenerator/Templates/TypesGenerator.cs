﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 14.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace WebApiProxyGenerator.Templates
{
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\dev\WebApiTypeScriptProxyGeneration\WebApiProxyGenerator\Templates\TypesGenerator.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    internal partial class TypesGenerator : TypesGeneratorBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("//------------------------------------------------------------------------------\r" +
                    "\n// <auto-generated>\r\n//     This code was generated by a tool.\r\n//     Runtime " +
                    "Version: ");
            
            #line 7 "C:\dev\WebApiTypeScriptProxyGeneration\WebApiProxyGenerator\Templates\TypesGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Environment.Version));
            
            #line default
            #line hidden
            this.Write("\r\n//\r\n//     Changes to this file may cause incorrect behavior and will be lost i" +
                    "f\r\n//     the code is regenerated.\r\n// </auto-generated>\r\n//--------------------" +
                    "----------------------------------------------------------\r\n\r\n\"use strict\";\r\n\r\n/" +
                    "/ Interfaces\r\n");
            
            #line 17 "C:\dev\WebApiTypeScriptProxyGeneration\WebApiProxyGenerator\Templates\TypesGenerator.tt"
 foreach(var @interface in this.Interfaces) { 
            
            #line default
            #line hidden
            this.Write("\r\nexport interface ");
            
            #line 19 "C:\dev\WebApiTypeScriptProxyGeneration\WebApiProxyGenerator\Templates\TypesGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(@interface.Name));
            
            #line default
            #line hidden
            this.Write(" {\r\n\r\n");
            
            #line 21 "C:\dev\WebApiTypeScriptProxyGeneration\WebApiProxyGenerator\Templates\TypesGenerator.tt"
    foreach(var member in @interface.Members) { 
            
            #line default
            #line hidden
            this.Write("\t");
            
            #line 22 "C:\dev\WebApiTypeScriptProxyGeneration\WebApiProxyGenerator\Templates\TypesGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(member.Name));
            
            #line default
            #line hidden
            this.Write("?: ");
            
            #line 22 "C:\dev\WebApiTypeScriptProxyGeneration\WebApiProxyGenerator\Templates\TypesGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GetTypeScriptFieldTypeName(member.Type)));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 23 "C:\dev\WebApiTypeScriptProxyGeneration\WebApiProxyGenerator\Templates\TypesGenerator.tt"
    } 
            
            #line default
            #line hidden
            this.Write("}\r\n");
            
            #line 25 "C:\dev\WebApiTypeScriptProxyGeneration\WebApiProxyGenerator\Templates\TypesGenerator.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\r\n// Enums\r\n");
            
            #line 29 "C:\dev\WebApiTypeScriptProxyGeneration\WebApiProxyGenerator\Templates\TypesGenerator.tt"
 foreach(var @enum in this.Enums) { 
            
            #line default
            #line hidden
            this.Write("\r\nexport enum ");
            
            #line 31 "C:\dev\WebApiTypeScriptProxyGeneration\WebApiProxyGenerator\Templates\TypesGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(@enum.Name));
            
            #line default
            #line hidden
            this.Write(" {\r\n");
            
            #line 32 "C:\dev\WebApiTypeScriptProxyGeneration\WebApiProxyGenerator\Templates\TypesGenerator.tt"
    foreach(var member in @enum.Members) { 
            
            #line default
            #line hidden
            this.Write("\t");
            
            #line 33 "C:\dev\WebApiTypeScriptProxyGeneration\WebApiProxyGenerator\Templates\TypesGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(member.Name));
            
            #line default
            #line hidden
            this.Write(" = ");
            
            #line 33 "C:\dev\WebApiTypeScriptProxyGeneration\WebApiProxyGenerator\Templates\TypesGenerator.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture((int)Enum.Parse(member.Type, member.Name)));
            
            #line default
            #line hidden
            this.Write(",\r\n");
            
            #line 34 "C:\dev\WebApiTypeScriptProxyGeneration\WebApiProxyGenerator\Templates\TypesGenerator.tt"
    } 
            
            #line default
            #line hidden
            this.Write("}\r\n");
            
            #line 36 "C:\dev\WebApiTypeScriptProxyGeneration\WebApiProxyGenerator\Templates\TypesGenerator.tt"
 } 
            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
        
        #line 37 "C:\dev\WebApiTypeScriptProxyGeneration\WebApiProxyGenerator\Templates\TypesGenerator.tt"

	/// <summary>
	/// Returns a corresponding TypeScript type for a given .NET type
	/// </summary>
	public static string GetTypeScriptFieldTypeName(Type type)
	{
		var numberTypes = new HashSet<Type>
		{
			typeof(sbyte), typeof(byte), typeof(short),
			typeof(ushort), typeof(int), typeof(uint),
			typeof(long), typeof(ulong), typeof(float),
			typeof(double), typeof(decimal)
		};
		var stringTypes = new HashSet<Type>
		{
			typeof(char), typeof(string), typeof(Guid)
		};

		var result = "";
		var isCollectionType = false;
		// Check if it is a generic. We support only generics which are compatible with IEnumerable<T> and have only one generic argument
		if (type.IsGenericType) {
			if (!typeof(IEnumerable<object>).IsAssignableFrom(type) && type.GetGenericArguments().Length > 1) {
				throw new Exception(string.Format("The generic type {0} must implement IEnumerable<T> and must have no more than 1 generic argument.", type.FullName));
			}
			// strip the generic type leaving the first generic argument
			type = type.GetGenericArguments()[0];
			isCollectionType = true;
		}

		// Check if it is a primitive type
		if (numberTypes.Contains(type)) result = "number";
		else if (stringTypes.Contains(type)) result = "string";
		else if (type == typeof(bool)) result = "boolean";
		// It is enum/class/struct -> return its name as-is
		else result = type.Name;

		if(isCollectionType) result += "[]";

		return result;
	}

        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    internal class TypesGeneratorBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}

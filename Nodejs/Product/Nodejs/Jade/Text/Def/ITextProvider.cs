﻿//*********************************************************//
//    Copyright (c) Microsoft. All rights reserved.
//    
//    Apache 2.0 License
//    
//    You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
//    
//    Unless required by applicable law or agreed to in writing, software 
//    distributed under the License is distributed on an "AS IS" BASIS, 
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or 
//    implied. See the License for the specific language governing 
//    permissions and limitations under the License.
//
//*********************************************************//

using System;

namespace Microsoft.NodejsTools.Jade {
    /// <summary>
    /// Text provider. HTML parser calls this interface to retrieve text.
    /// Can be implemented on a string <seealso cref="TextStream"/> or
    /// on a Visual Studio ITextBuffer (see Microsoft.Html.Editor implementation)
    /// </summary>
    interface ITextProvider {
        /// <summary>Text length</summary>
        int Length { get; }

        /// <summary>
        /// Retrieves character at a given position. 
        /// Returns 0 if index is out of range. Must no throw.
        /// </summary>
        char this[int position] { get; }

        /// <summary>Retrieves a substring from text rangen</summary>
        string GetText(ITextRange range);

        /// <summary>Finds first index of a text sequence. Returns -1 if not found.</summary>
        int IndexOf(string text, int startPosition, bool ignoreCase);

        /// <summary>Finds first index of a text sequence. Returns -1 if not found.</summary>
        int IndexOf(string text, ITextRange range, bool ignoreCase);

        /// <summary>Compares text range to a given string.</summary>
        bool CompareTo(int position, int length, string text, bool ignoreCase);

        /// <summary>Clones text provider and all its data (typically for use in another thread).</summary>
        ITextProvider Clone();

        /// <summary>Snapshot version.</summary>
        int Version { get; }

        /// <summary>Fires when text buffer content changes.</summary>
        event EventHandler<TextChangeEventArgs> OnTextChange;
    }
}

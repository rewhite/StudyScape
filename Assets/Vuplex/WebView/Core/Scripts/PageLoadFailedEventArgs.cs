// Copyright (c) 2023 Vuplex Inc. All rights reserved.
//
// Licensed under the Vuplex Commercial Software Library License, you may
// not use this file except in compliance with the License. You may obtain
// a copy of the License at
//
//     https://vuplex.com/commercial-library-license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
namespace Vuplex.WebView {

    /// <summary>
    /// Event args for IWebView.PageLoadFailed.
    /// </summary>
    public class PageLoadFailedEventArgs : System.EventArgs {

        public readonly string NativeErrorCode;

        public readonly string Url;

        public PageLoadFailedEventArgs(string nativeErrorCode, string url) {

            NativeErrorCode = nativeErrorCode;
            Url = url;
        }

        public override string ToString() => $"NativeErrorCode = {NativeErrorCode}, Url = {Url}";
    }
}

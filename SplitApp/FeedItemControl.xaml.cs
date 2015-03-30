using SplitApp.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace SplitApp
{
    public sealed partial class FeedItemControl : UserControl
    {
        public FeedItemControl()
        {
            this.InitializeComponent();
        }

        private bool underlining = false;
        private void UserControl_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            System.Diagnostics.Debug.WriteLine("Data Context Changed...");
            Element post = (Element)args.NewValue;
            Paragraph p = new Paragraph();
            if (post != null)
            {
                foreach (Messagesegment ms in post.body.messageSegments)
                {
                    RenderMessageSegment(ms, p);
                }
                if (post.capabilities.enhancedLink != null)
                {
                    RenderEnhancedLink(post.capabilities.enhancedLink, p);
                }
            }
        }

        private void RenderEnhancedLink(Enhancedlink link, Paragraph p)
        {
            System.Diagnostics.Debug.WriteLine("Enhanced link\n\n" + link.description);
            System.Diagnostics.Debug.WriteLine(link.title);
            System.Diagnostics.Debug.WriteLine(link.linkRecordId);
            System.Diagnostics.Debug.WriteLine(link.linkUrl);
            System.Diagnostics.Debug.WriteLine(link.icon.url);
        }

        private void RenderMessageSegment(Messagesegment ms, Paragraph p)
        {
            switch ( ms.type ) {
                case "Mention":
                    underlining = true;
                    System.Diagnostics.Debug.WriteLine("Got an @ mention.");
                    break;
                case "Text":
                    
                    System.Diagnostics.Debug.WriteLine("Got a text segment.");
                    break;
                default:
                    return;
            }

        }
    }
}

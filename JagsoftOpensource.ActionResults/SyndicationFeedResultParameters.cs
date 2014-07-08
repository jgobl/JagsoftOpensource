using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace JagsoftOpensource.ActionResults
{
    public class SyndicationFeedResultParameters
    {
        public SyndicationFeedFormatter FeedFormatter { get; set; }
        public string ContentType { get; set; }
    }
}

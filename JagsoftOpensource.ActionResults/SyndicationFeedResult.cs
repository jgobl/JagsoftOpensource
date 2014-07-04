using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml;

namespace JagsoftOpensource.ActionResults
{
    public class SyndicationFeedResult : ActionResult
    {
        #region private Members

        private SyndicationFeedResultsParameters syndicationFeedResultsParameters;

        #endregion

        #region Public Properties

        public SyndicationFeedResultsParameters SyndicationFeedResultsParameters
        {
            get
            {
                return syndicationFeedResultsParameters;
            }
        }


        #endregion


        #region Public Constructors

        public SyndicationFeedResult(SyndicationFeedResultsParameters syndicationFeedResultsParameters)
        {
            this.syndicationFeedResultsParameters = syndicationFeedResultsParameters;
        }

        #endregion

        #region Public Overrides

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.RequestContext.HttpContext.Response;

            response.ContentType = syndicationFeedResultsParameters.ContentType;

            using (var xmlWriter = new XmlTextWriter(response.Output))
            {
                xmlWriter.Formatting = Formatting.Indented;
                syndicationFeedResultsParameters.FeedFormatter.WriteTo(xmlWriter);
            }
        }

        #endregion
    }
}

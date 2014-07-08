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

        private SyndicationFeedResultParameters syndicationFeedResultParameters;

        #endregion

        #region Public Properties

        public SyndicationFeedResultParameters SyndicationFeedResultParameters
        {
            get
            {
                return syndicationFeedResultParameters;
            }
        }


        #endregion


        #region Public Constructors

        public SyndicationFeedResult(SyndicationFeedResultParameters syndicationFeedResultParameters)
        {
            this.syndicationFeedResultParameters = syndicationFeedResultParameters;
        }

        #endregion

        #region Public Overrides

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.RequestContext.HttpContext.Response;

            response.ContentType = syndicationFeedResultParameters.ContentType;

            using (var xmlWriter = new XmlTextWriter(response.Output))
            {
                xmlWriter.Formatting = Formatting.Indented;
                syndicationFeedResultParameters.FeedFormatter.WriteTo(xmlWriter);
            }
        }

        #endregion
    }
}

namespace Sitecore.Support.Pipelines.RenderField
{
    using Sitecore.Xml.Xsl;
    using System;

    public class GetImageFieldValue
    {
        protected virtual ImageRenderer CreateRenderer() =>
            new ImageRenderer();

        public void Process(Sitecore.Pipelines.RenderField.RenderFieldArgs args)
        {
            if (args.FieldTypeKey == "image")
            {
                ImageRenderer renderer = this.CreateRenderer();
                renderer.Item = args.Item;
                renderer.FieldName = args.FieldName;
                renderer.FieldValue = args.FieldValue;
                renderer.Parameters = args.Parameters;
                args.WebEditParameters.AddRange(args.Parameters);
                renderer.Parameters.Add("la", args.Item.Language.Name);
                RenderFieldResult result = renderer.Render();
                args.Result.FirstPart = result.FirstPart;
                args.Result.LastPart = result.LastPart;
                args.DisableWebEditContentEditing = true;
                args.DisableWebEditFieldWrapping = true;
                args.WebEditClick = "return Sitecore.WebEdit.editControl($JavascriptParameters, 'webedit:chooseimage')";
            }
        }
    }
}

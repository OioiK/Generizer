namespace Generizer.Forms.Controls
{
    internal class ButtonControl : IControl
    {
        public string Class { get; set; }
        public string Text { get; set; }

        public string GenerateHtml()
        {
            var html = $"<div><p><button class=\'{this.Class}\' \'data-bind=click: showMessage()\' >{this.Text}</button></p></div>";
            return html;
        }
    }
}

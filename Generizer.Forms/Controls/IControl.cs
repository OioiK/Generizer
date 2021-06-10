namespace Generizer.Forms.Controls
{
    internal interface IControl
    {
        string Class { get; set; }
        string GenerateHtml();
    }
}

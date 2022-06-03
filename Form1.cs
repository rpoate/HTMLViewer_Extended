namespace HTMLViewer_Extended
{
    public partial class Form1 : Form
    {
        ContextMenuStrip oContext;

        public Form1()
        {
            InitializeComponent();

            this.htmlEditControl1.CSSText = "body {font-family: Arial}";
            this.htmlEditControl1.DocumentHTML = "<p>paragraph 1</p><p>paragraph 2</p><p>paragraph 3</p><p>paragraph 4</p>";

            this.htmlEditControl1.MouseDown += HtmlEditControl1_MouseDown;
            this.htmlEditControl1.CancellableUserInteraction += HtmlEditControl1_CancellableUserInteraction;
            MenuStrip oMenu = new MenuStrip();
            oMenu.Items.Add("Viewer Mode").Click += ViewerMode_Click; ;
            oMenu.Items.Add("Edit Mode").Click += EditMode_Click; ;

            this.Controls.Add(oMenu);

            oContext = new ContextMenuStrip();

            oContext.Items.Add("Copy").Click += CopyContextItem_Click;
        }

        private void HtmlEditControl1_CancellableUserInteraction(object sender, Zoople.CancellableUserInteractionEventsArgs e)
        {
            if (htmlEditControl1.EditingDisabled && e.Keys.Keycode == (int)Keys.C && e.Keys.Control)
            {
                if (htmlEditControl1.CurrentSelection.htmlText != null)
                    this.htmlEditControl1.copy_document();
            }
        }

        private void HtmlEditControl1_MouseDown(object? sender, MouseEventArgs e)
        {
            if (htmlEditControl1.EditingDisabled && ((int)e.Button) == 2)
            {
                if (htmlEditControl1.CurrentSelection.htmlText != null)
                    oContext.Show(PointToScreen(e.Location));
            }
        }

        private void CopyContextItem_Click(object? sender, EventArgs e)
        {
            this.htmlEditControl1.copy_document();
        }

        private void EditMode_Click(object? sender, EventArgs e)
        {
            this.htmlEditControl1.EditingDisabled = false;
            this.htmlEditControl1.HideDOMToolbar = false;
            this.htmlEditControl1.HideMainToolbar = false;
        }

        private void ViewerMode_Click(object? sender, EventArgs e)
        {
            this.htmlEditControl1.EditingDisabled = true;
            this.htmlEditControl1.HideDOMToolbar = true;
            this.htmlEditControl1.HideMainToolbar = true;
        }
    }
}
namespace TransformX;

partial class MainForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        menuStrip1 = new MenuStrip();
        файлToolStripMenuItem = new ToolStripMenuItem();
        открытьToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator1 = new ToolStripSeparator();
        сохранитьToolStripMenuItem = new ToolStripMenuItem();
        сохранитьКакToolStripMenuItem = new ToolStripMenuItem();
        toolStripSeparator2 = new ToolStripSeparator();
        выходToolStripMenuItem = new ToolStripMenuItem();
        правкаToolStripMenuItem = new ToolStripMenuItem();
        видToolStripMenuItem = new ToolStripMenuItem();
        настройкиToolStripMenuItem = new ToolStripMenuItem();
        splitContainer1 = new SplitContainer();
        tabControl1 = new TabControl();
        menuStrip1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.SuspendLayout();
        SuspendLayout();
        // 
        // menuStrip1
        // 
        menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, правкаToolStripMenuItem, видToolStripMenuItem, настройкиToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(800, 24);
        menuStrip1.TabIndex = 1;
        menuStrip1.Text = "menuStrip1";
        // 
        // файлToolStripMenuItem
        // 
        файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { открытьToolStripMenuItem, toolStripSeparator1, сохранитьToolStripMenuItem, сохранитьКакToolStripMenuItem, toolStripSeparator2, выходToolStripMenuItem });
        файлToolStripMenuItem.Name = "файлToolStripMenuItem";
        файлToolStripMenuItem.Padding = new Padding(2, 0, 2, 0);
        файлToolStripMenuItem.Size = new Size(44, 20);
        файлToolStripMenuItem.Text = "Файл";
        // 
        // открытьToolStripMenuItem
        // 
        открытьToolStripMenuItem.Image = Properties.Resources.openHS;
        открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
        открытьToolStripMenuItem.Size = new Size(217, 22);
        открытьToolStripMenuItem.Text = "Открыть";
        // 
        // toolStripSeparator1
        // 
        toolStripSeparator1.Name = "toolStripSeparator1";
        toolStripSeparator1.Size = new Size(214, 6);
        // 
        // сохранитьToolStripMenuItem
        // 
        сохранитьToolStripMenuItem.Image = Properties.Resources.saveHS;
        сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
        сохранитьToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
        сохранитьToolStripMenuItem.Size = new Size(217, 22);
        сохранитьToolStripMenuItem.Text = "Сохранить";
        // 
        // сохранитьКакToolStripMenuItem
        // 
        сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
        сохранитьКакToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.S;
        сохранитьКакToolStripMenuItem.Size = new Size(217, 22);
        сохранитьКакToolStripMenuItem.Text = "Сохранить как";
        // 
        // toolStripSeparator2
        // 
        toolStripSeparator2.Name = "toolStripSeparator2";
        toolStripSeparator2.Size = new Size(214, 6);
        // 
        // выходToolStripMenuItem
        // 
        выходToolStripMenuItem.Name = "выходToolStripMenuItem";
        выходToolStripMenuItem.Size = new Size(217, 22);
        выходToolStripMenuItem.Text = "Выход";
        // 
        // правкаToolStripMenuItem
        // 
        правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
        правкаToolStripMenuItem.Padding = new Padding(2, 0, 2, 0);
        правкаToolStripMenuItem.Size = new Size(55, 20);
        правкаToolStripMenuItem.Text = "Правка";
        // 
        // видToolStripMenuItem
        // 
        видToolStripMenuItem.Name = "видToolStripMenuItem";
        видToolStripMenuItem.Padding = new Padding(2, 0, 2, 0);
        видToolStripMenuItem.Size = new Size(35, 20);
        видToolStripMenuItem.Text = "Вид";
        // 
        // настройкиToolStripMenuItem
        // 
        настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
        настройкиToolStripMenuItem.Padding = new Padding(2, 0, 2, 0);
        настройкиToolStripMenuItem.Size = new Size(75, 20);
        настройкиToolStripMenuItem.Text = "Настройки";
        // 
        // splitContainer1
        // 
        splitContainer1.BorderStyle = BorderStyle.FixedSingle;
        splitContainer1.Dock = DockStyle.Fill;
        splitContainer1.Location = new Point(0, 24);
        splitContainer1.Name = "splitContainer1";
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.Controls.Add(tabControl1);
        splitContainer1.Size = new Size(800, 426);
        splitContainer1.SplitterDistance = 586;
        splitContainer1.TabIndex = 2;
        // 
        // tabControl1
        // 
        tabControl1.Dock = DockStyle.Fill;
        tabControl1.Location = new Point(0, 0);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(584, 424);
        tabControl1.TabIndex = 0;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(splitContainer1);
        Controls.Add(menuStrip1);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "TransformX";
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        splitContainer1.Panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MenuStrip menuStrip1;
    private ToolStripMenuItem файлToolStripMenuItem;
    private ToolStripMenuItem правкаToolStripMenuItem;
    private ToolStripMenuItem видToolStripMenuItem;
    private ToolStripMenuItem настройкиToolStripMenuItem;
    private ToolStripMenuItem открытьToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem сохранитьToolStripMenuItem;
    private ToolStripMenuItem сохранитьКакToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem выходToolStripMenuItem;
    private SplitContainer splitContainer1;
    private TabControl tabControl1;
}
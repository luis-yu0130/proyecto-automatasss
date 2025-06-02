namespace proyecto_automatas
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Controls
        private System.Windows.Forms.TextBox textBoxExpresionMatematica;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.TreeView treeViewDerivacion;
        private System.Windows.Forms.ListBox listBoxHistorial;
        private System.Windows.Forms.Label labelArbol;
        private System.Windows.Forms.Label labelHistorial;

        /// <summary>
        ///  Clean up any resources being used.
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

        private void InitializeComponent()
        {
            textBoxExpresionMatematica = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            button14 = new Button();
            button15 = new Button();
            button16 = new Button();
            button18 = new Button();
            button19 = new Button();
            button20 = new Button();
            button21 = new Button();
            treeViewDerivacion = new TreeView();
            listBoxHistorial = new ListBox();
            labelArbol = new Label();
            labelHistorial = new Label();
            textBox1 = new TextBox();
            button22 = new Button();
            label1 = new Label();
            button17 = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            listBoxDerivacion = new ListBox();
            tabPage4 = new TabPage();
            listBoxDerivacionJF = new ListBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxExpresionMatematica
            // 
            textBoxExpresionMatematica.Location = new Point(66, 49);
            textBoxExpresionMatematica.Name = "textBoxExpresionMatematica";
            textBoxExpresionMatematica.Size = new Size(260, 23);
            textBoxExpresionMatematica.TabIndex = 0;
            textBoxExpresionMatematica.TextChanged += textBoxExpresionMatematica_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(332, 47);
            button1.Name = "button1";
            button1.Size = new Size(78, 26);
            button1.TabIndex = 1;
            button1.Text = "Evaluar";
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(30, 24);
            button2.Name = "button2";
            button2.Size = new Size(40, 30);
            button2.TabIndex = 2;
            button2.Text = "(";
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(76, 24);
            button3.Name = "button3";
            button3.Size = new Size(40, 30);
            button3.TabIndex = 3;
            button3.Text = ")";
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(122, 24);
            button4.Name = "button4";
            button4.Size = new Size(40, 30);
            button4.TabIndex = 4;
            button4.Text = "C";
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(168, 24);
            button5.Name = "button5";
            button5.Size = new Size(40, 30);
            button5.TabIndex = 5;
            button5.Text = "^";
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(30, 60);
            button6.Name = "button6";
            button6.Size = new Size(40, 30);
            button6.TabIndex = 6;
            button6.Text = "7";
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(76, 60);
            button7.Name = "button7";
            button7.Size = new Size(40, 30);
            button7.TabIndex = 7;
            button7.Text = "8";
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(122, 60);
            button8.Name = "button8";
            button8.Size = new Size(40, 30);
            button8.TabIndex = 8;
            button8.Text = "9";
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.Location = new Point(168, 60);
            button9.Name = "button9";
            button9.Size = new Size(40, 30);
            button9.TabIndex = 9;
            button9.Text = "/";
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(30, 100);
            button10.Name = "button10";
            button10.Size = new Size(40, 30);
            button10.TabIndex = 10;
            button10.Text = "4";
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.Location = new Point(76, 100);
            button11.Name = "button11";
            button11.Size = new Size(40, 30);
            button11.TabIndex = 11;
            button11.Text = "5";
            button11.Click += button11_Click;
            // 
            // button12
            // 
            button12.Location = new Point(122, 100);
            button12.Name = "button12";
            button12.Size = new Size(40, 30);
            button12.TabIndex = 12;
            button12.Text = "6";
            button12.Click += button12_Click;
            // 
            // button13
            // 
            button13.Location = new Point(168, 100);
            button13.Name = "button13";
            button13.Size = new Size(40, 30);
            button13.TabIndex = 13;
            button13.Text = "*";
            button13.Click += button13_Click;
            // 
            // button14
            // 
            button14.Location = new Point(30, 140);
            button14.Name = "button14";
            button14.Size = new Size(40, 30);
            button14.TabIndex = 14;
            button14.Text = "1";
            button14.Click += button14_Click;
            // 
            // button15
            // 
            button15.Location = new Point(76, 140);
            button15.Name = "button15";
            button15.Size = new Size(40, 30);
            button15.TabIndex = 15;
            button15.Text = "2";
            button15.Click += button15_Click;
            // 
            // button16
            // 
            button16.Location = new Point(122, 140);
            button16.Name = "button16";
            button16.Size = new Size(40, 30);
            button16.TabIndex = 16;
            button16.Text = "3";
            button16.Click += button16_Click;
            // 
            // button18
            // 
            button18.Location = new Point(30, 180);
            button18.Name = "button18";
            button18.Size = new Size(40, 30);
            button18.TabIndex = 18;
            button18.Text = "0";
            button18.Click += button18_Click;
            // 
            // button19
            // 
            button19.Location = new Point(76, 180);
            button19.Name = "button19";
            button19.Size = new Size(40, 30);
            button19.TabIndex = 19;
            button19.Text = "00";
            button19.Click += button19_Click;
            // 
            // button20
            // 
            button20.Location = new Point(122, 180);
            button20.Name = "button20";
            button20.Size = new Size(40, 30);
            button20.TabIndex = 20;
            button20.Text = ".";
            button20.Click += button20_Click;
            // 
            // button21
            // 
            button21.Location = new Point(168, 180);
            button21.Name = "button21";
            button21.Size = new Size(40, 30);
            button21.TabIndex = 21;
            button21.Text = "+";
            button21.Click += button21_Click;
            // 
            // treeViewDerivacion
            // 
            treeViewDerivacion.Location = new Point(-4, 0);
            treeViewDerivacion.Name = "treeViewDerivacion";
            treeViewDerivacion.Size = new Size(606, 309);
            treeViewDerivacion.TabIndex = 23;
            // 
            // listBoxHistorial
            // 
            listBoxHistorial.Location = new Point(0, 0);
            listBoxHistorial.Name = "listBoxHistorial";
            listBoxHistorial.Size = new Size(606, 310);
            listBoxHistorial.TabIndex = 25;
            // 
            // labelArbol
            // 
            labelArbol.AutoSize = true;
            labelArbol.Location = new Point(652, 68);
            labelArbol.Name = "labelArbol";
            labelArbol.Size = new Size(0, 17);
            labelArbol.TabIndex = 24;
            // 
            // labelHistorial
            // 
            labelHistorial.AutoSize = true;
            labelHistorial.Location = new Point(801, 209);
            labelHistorial.Name = "labelHistorial";
            labelHistorial.Size = new Size(0, 17);
            labelHistorial.TabIndex = 26;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(168, 78);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(158, 23);
            textBox1.TabIndex = 27;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button22
            // 
            button22.Location = new Point(332, 78);
            button22.Name = "button22";
            button22.Size = new Size(78, 26);
            button22.TabIndex = 28;
            button22.Text = "Limpiar";
            button22.Click += button22_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(96, 84);
            label1.Name = "label1";
            label1.Size = new Size(66, 17);
            label1.TabIndex = 29;
            label1.Text = "Resultado";
            // 
            // button17
            // 
            button17.Location = new Point(168, 140);
            button17.Name = "button17";
            button17.Size = new Size(40, 30);
            button17.TabIndex = 17;
            button17.Text = "-";
            button17.Click += button17_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(42, 122);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(610, 335);
            tabControl1.TabIndex = 30;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button7);
            tabPage1.Controls.Add(button21);
            tabPage1.Controls.Add(button20);
            tabPage1.Controls.Add(button19);
            tabPage1.Controls.Add(button18);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(button17);
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(button16);
            tabPage1.Controls.Add(button4);
            tabPage1.Controls.Add(button15);
            tabPage1.Controls.Add(button5);
            tabPage1.Controls.Add(button14);
            tabPage1.Controls.Add(button6);
            tabPage1.Controls.Add(button13);
            tabPage1.Controls.Add(button12);
            tabPage1.Controls.Add(button8);
            tabPage1.Controls.Add(button11);
            tabPage1.Controls.Add(button9);
            tabPage1.Controls.Add(button10);
            tabPage1.Location = new Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(602, 305);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Expresion Matematica";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(treeViewDerivacion);
            tabPage2.Location = new Point(4, 26);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(602, 305);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Arbol de derivacion";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(listBoxDerivacionJF);
            tabPage3.Controls.Add(listBoxDerivacion);
            tabPage3.Location = new Point(4, 26);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(602, 305);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Tabla de derivacion";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // listBoxDerivacion
            // 
            listBoxDerivacion.Location = new Point(-2, -3);
            listBoxDerivacion.Name = "listBoxDerivacion";
            listBoxDerivacion.Size = new Size(269, 310);
            listBoxDerivacion.TabIndex = 26;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(listBoxHistorial);
            tabPage4.Location = new Point(4, 26);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(602, 305);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Historial de Expresion";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // listBoxDerivacionJF
            // 
            listBoxDerivacionJF.Location = new Point(266, -1);
            listBoxDerivacionJF.Name = "listBoxDerivacionJF";
            listBoxDerivacionJF.Size = new Size(340, 310);
            listBoxDerivacionJF.TabIndex = 27;
            // 
            // Form1
            // 
            ClientSize = new Size(691, 480);
            Controls.Add(label1);
            Controls.Add(labelArbol);
            Controls.Add(button22);
            Controls.Add(textBox1);
            Controls.Add(textBoxExpresionMatematica);
            Controls.Add(button1);
            Controls.Add(labelHistorial);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Analizador Léxico";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button22;
        private Label label1;
        private Button button17;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private ListBox listBoxDerivacion;
        private ListBox listBoxDerivacionJF;
    }
}

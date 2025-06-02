using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace proyecto_automatas
{
    public partial class Form1 : Form
    {
        private List<string> ListaDeToken;
        private int pos;
        private string TokenActual;

        private class NodoArbol
        {
            public string Valor { get; set; }
            public List<NodoArbol> Hijos { get; set; }
            public double Resultado { get; set; }

            public NodoArbol(string valor, double resultado = 0)
            {
                Valor = valor;
                Hijos = new List<NodoArbol>();
                Resultado = resultado;
            }
        }

        private NodoArbol raizArbol;
        private List<string> historialExpresiones = new List<string>();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;

        }

        // Analizador léxico: convierte la expresión en una lista de tokens
        private List<string> AnalizadorLexico(string expresion)
        {
            List<string> tokens = new List<string>();
            string patron = @"(\d+(\.\d+)?|[+\-*/^()])";
            MatchCollection coincidencias = Regex.Matches(expresion, patron);

            foreach (Match match in coincidencias)
            {
                tokens.Add(match.Value);
            }

            return tokens;
        }

        private void GetNextToken()
        {
            if (pos < ListaDeToken.Count)
            {
                TokenActual = ListaDeToken[pos];
                pos++;
            }
            else
            {
                TokenActual = null;
            }
        }

        private List<string> pasosDerivacion = new List<string>(); // Declarar nueva lista

        private double Expresion(NodoArbol nodoActual = null)
        {
            pasosDerivacion.Clear();
            pasosDerivacion.Add("Expresión");
            pasosDerivacion.Add("Expresión → Expresión + Término");

            string derivacionActual = "Expresión";
            pasosDerivacion.Add(derivacionActual);

            derivacionActual = derivacionActual.Replace("Expresión", "Expresión + Término");
            pasosDerivacion.Add(derivacionActual);

            derivacionActual = derivacionActual.Replace("Expresión", "Término");
            pasosDerivacion.Add(derivacionActual);

            var nodo = nodoActual ?? new NodoArbol("Expresión");
            if (raizArbol == null) raizArbol = nodo;
            tablaDerivacion.Add("Expresión");

            var primerTermino = new NodoArbol("Término");
            nodo.Hijos.Add(primerTermino);
            double resultado = Termino(primerTermino);

            if (TokenActual == "+" || TokenActual == "-")
            {
                while (TokenActual == "+" || TokenActual == "-")
                {
                    string operador = TokenActual;
                    nodo.Hijos.Add(new NodoArbol(operador));
                    tablaDerivacion.Add("Expresión → Expresión " + operador + " Término");

                    GetNextToken();

                    var siguienteTermino = new NodoArbol("Término");
                    nodo.Hijos.Add(siguienteTermino);
                    double segundoOperando = Termino(siguienteTermino);

                    resultado = operador == "+" ? resultado + segundoOperando : resultado - segundoOperando;
                }
            }
            else
            {
                tablaDerivacion.Add("Expresión → Término");
                listBoxDerivacion.Items.Clear();

                int maxFilas = Math.Max(tablaDerivacion.Count, pasosDerivacion.Count);

                for (int i = 0; i < maxFilas; i++)
                {
                    string regla = i < tablaDerivacion.Count ? tablaDerivacion[i] : "";
                    string paso = i < pasosDerivacion.Count ? pasosDerivacion[i] : "";

                    ListViewItem item = new ListViewItem(regla);
                    item.SubItems.Add(paso);
                    listBoxDerivacion.Items.Add(item);
                }

            }

            nodo.Resultado = resultado;
            return resultado;
        }
        private double Termino(NodoArbol nodoActual)
        {
            var primerFactor = new NodoArbol("Factor");
            nodoActual.Hijos.Add(primerFactor);
            double resultado = Factor(primerFactor);

            if (TokenActual == "*" || TokenActual == "/")
            {
                while (TokenActual == "*" || TokenActual == "/")
                {
                    string operador = TokenActual;
                    nodoActual.Hijos.Add(new NodoArbol(operador));
                    tablaDerivacion.Add("Término → Término " + operador + " Factor");

                    GetNextToken();
                    var siguienteFactor = new NodoArbol("Factor");
                    nodoActual.Hijos.Add(siguienteFactor);
                    double segundoOperando = Factor(siguienteFactor);

                    resultado = operador == "*" ? resultado * segundoOperando : resultado / segundoOperando;
                }
            }
            else
            {
                tablaDerivacion.Add("Término → Factor");
            }

            nodoActual.Resultado = resultado;
            return resultado;
        }

        private double Factor(NodoArbol nodoActual)
        {
            double resultado;

            if (TokenActual == "(")
            {
                nodoActual.Valor = "Factor";
                tablaDerivacion.Add("Factor → ( Expresión )");

                GetNextToken();
                var expresionInterna = new NodoArbol("Expresión");
                nodoActual.Hijos.Add(expresionInterna);
                resultado = Expresion(expresionInterna);

                if (TokenActual != ")")
                    throw new Exception("Se esperaba un paréntesis de cierre ')'");

                GetNextToken();
            }
            else if (double.TryParse(TokenActual, out resultado))
            {
                nodoActual.Valor = "Factor";
                tablaDerivacion.Add("Factor → Número");
                tablaDerivacion.Add("Número → Dígito");
                tablaDerivacion.Add("Dígito → " + TokenActual);

                var nodoNumero = new NodoArbol("Número");
                var nodoValor = new NodoArbol("Dígito → " + TokenActual);
                nodoNumero.Hijos.Add(nodoValor);
                nodoActual.Hijos.Add(nodoNumero);

                GetNextToken();
            }
            else
            {
                throw new Exception($"Token no esperado: {TokenActual}");
            }

            if (TokenActual == "^")
            {
                var nodoExponente = new NodoArbol("^");
                nodoActual.Hijos.Add(nodoExponente);
                tablaDerivacion.Add("Factor → Factor ^ Factor");

                GetNextToken();
                var factorExponente = new NodoArbol("Factor");
                nodoActual.Hijos.Add(factorExponente);
                double exponente = Factor(factorExponente);
                resultado = Math.Pow(resultado, exponente);
            }

            return resultado;
        }


        private void MostrarArbolEnTreeView(NodoArbol nodo, TreeNode nodoPadre)
        {
            string etiqueta = nodo.Valor;
            TreeNode nuevoNodo = nodoPadre == null ?
                treeViewDerivacion.Nodes.Add(etiqueta) :
                nodoPadre.Nodes.Add(etiqueta);

            foreach (var hijo in nodo.Hijos)
            {
                MostrarArbolEnTreeView(hijo, nuevoNodo);
            }
        }

        private List<string> tablaDerivacion = new List<string>();

        private void button11_Click(object sender, EventArgs e)
        {
            textBoxExpresionMatematica.Text += "5";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string texto = textBoxExpresionMatematica.Text;

            if (string.IsNullOrEmpty(texto))
                return;

            // Intenta detectar el último token
            MatchCollection tokens = Regex.Matches(texto, @"(\d+(\.\d+)?|[+\-*/^()])");

            if (tokens.Count == 0)
                return;

            Match ultimoToken = tokens[tokens.Count - 1];

            int inicio = ultimoToken.Index;
            int longitud = ultimoToken.Length;

            if (Regex.IsMatch(ultimoToken.Value, @"^\d+(\.\d+)?$") && ultimoToken.Value.Length > 1)
            {
                // Es número y tiene más de un dígito → borramos solo el último dígito
                string nuevoNumero = ultimoToken.Value.Substring(0, ultimoToken.Value.Length - 1);
                texto = texto.Substring(0, inicio) + nuevoNumero;
            }
            else
            {
                // Es operador, paréntesis o número de 1 solo carácter → bórralo completo
                texto = texto.Substring(0, inicio);
            }

            textBoxExpresionMatematica.Text = texto;
        }

        private void textBoxExpresionMatematica_TextChanged(object sender, EventArgs e)
        {
            // No agregar texto automáticamente aquí
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBoxExpresionMatematica.Text += "+";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBoxExpresionMatematica.Text += "1";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBoxExpresionMatematica.Text += "2";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBoxExpresionMatematica.Text += "3";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBoxExpresionMatematica.Text += "4";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBoxExpresionMatematica.Text += "6";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBoxExpresionMatematica.Text += "7";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBoxExpresionMatematica.Text += "8";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBoxExpresionMatematica.Text += "9";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBoxExpresionMatematica.Text += "0";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBoxExpresionMatematica.Text += "00";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxExpresionMatematica.Text += "(";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxExpresionMatematica.Text += ")";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBoxExpresionMatematica.Text += "-";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBoxExpresionMatematica.Text += "*";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBoxExpresionMatematica.Text += "/";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBoxExpresionMatematica.Text += "^";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBoxExpresionMatematica.Text += ".";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string expresion = textBoxExpresionMatematica.Text.Trim();
                if (string.IsNullOrEmpty(expresion))
                {
                    MessageBox.Show("Por favor ingrese una expresión matemática.", "Error");
                    return;
                }

                ListaDeToken = AnalizadorLexico(expresion);
                pos = 0;
                raizArbol = null;
                tablaDerivacion.Clear();
                GetNextToken();

                double resultado = Expresion();

                if (TokenActual != null)
                    throw new Exception("Tokens adicionales después del final de la expresión");

                // Actualizar árbol
                treeViewDerivacion.Nodes.Clear();
                MostrarArbolEnTreeView(raizArbol, null);
                treeViewDerivacion.ExpandAll();

                // Mostrar tabla de derivación
                listBoxDerivacion.Items.Clear();
                foreach (string regla in tablaDerivacion)
                {
                    listBoxDerivacion.Items.Add(regla);
                }
                tablaDerivacion.Clear();

                // Historial
                string entradaHistorial = $"{expresion} = {resultado}";
                listBoxHistorial.Items.Insert(0, entradaHistorial);

                int maxFilas = Math.Max(tablaDerivacion.Count, pasosDerivacion.Count);

                for (int i = 0; i < maxFilas; i++)
                {
                    string produccion = i < tablaDerivacion.Count ? tablaDerivacion[i] : "";
                    string paso = i < pasosDerivacion.Count ? pasosDerivacion[i] : "";


                }
                MessageBox.Show($"Resultado: {resultado}", "Análisis Sintáctico Exitoso");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de análisis: {ex.Message}", "Error");
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            textBoxExpresionMatematica.Text = "";
            textBox1.Text = "";
            treeViewDerivacion.Nodes.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string expresion = textBoxExpresionMatematica.Text;

            if (string.IsNullOrWhiteSpace(expresion))
            {
                textBox1.Text = "";
                return;
            }

            try
            {
                ListaDeToken = AnalizadorLexico(expresion);
                pos = 0;
                raizArbol = null;
                GetNextToken();

                double resultado = Expresion();

                if (TokenActual != null)
                    return; // Tokens adicionales → no mostrar nada

                textBox1.Text = resultado.ToString();
            }
            catch
            {
                textBox1.Text = ""; // No mostrar "Error", solo vaciar
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Configurar columnas para mostrar Producción + Cadena derivada estilo JFLAP
            listBoxDerivacionJF.Items.Clear();
            foreach (string paso in pasosDerivacion)
            {
                listBoxDerivacionJF.Items.Add(paso);
            }

            // Botones numéricos (texto negro)
            Button[] botonesNumeros = {
        button14, // 1
        button15, // 2
        button16, // 3
        button10, // 4
        button11, // 5
        button12, // 6
        button6,  // 7
        button7,  // 8
        button8,  // 9
        button18, // 0
        button19, // 00
        button20  // .
    };

            // Botones de operadores y signos (texto blanco)
            Button[] botonesOperadores = {
        button21, // +
        button17, // -
        button13, // *
        button9,  // /
        button5,  // ^
        button2,  // (
        button3,  // )
        button4   // C (retroceso)
    };

            // Aplicar estilo a números
            foreach (var btn in botonesNumeros)
            {
                btn.BackColor = Color.LightSkyBlue;
                btn.ForeColor = Color.Black;
                btn.FlatStyle = FlatStyle.Flat;
            }

            // Aplicar estilo a operadores
            foreach (var btn in botonesOperadores)
            {
                btn.BackColor = Color.SteelBlue;
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
            }
        }
    }
}
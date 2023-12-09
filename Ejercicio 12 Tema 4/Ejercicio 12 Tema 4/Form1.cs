using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_12_Tema_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool bisiesto(int ano)
        {
            int resto4;
            int resto100;
            int resto400;
            bool bisiesto = false;

            resto4 = ano % 4;
            resto100 = ano % 100;
            resto400 = ano % 400;
            //Si es divisible entre 4 y no entre 100 consideramos que es bisiesto.
            if (resto4 == 0 && resto100 != 0)
            {
                bisiesto = true;
            }
            //Si es divisible entre 400 es bisiesto.
            if (resto4 == 0 && resto400 == 0)
            {
                bisiesto = true;
            }
            return bisiesto;
        }

        bool fechaValida(int dia, int mes, int ano)
        {
            bool fecha = false;
            bool diaCorrecto = false;
            bool mesCorrecto = mes > 0 && mes <= 12;

            if (mes == 4 || mes == 6 || mes == 9 || mes == 11)
            {
                diaCorrecto = dia > 0 && dia <= 30;
            }
            if (mes == 2)
            {
                diaCorrecto = dia > 0 && dia <= 28;
                if (bisiesto(ano) == true)
                {
                    diaCorrecto = dia > 0 && dia <= 29;
                }
            }
            if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
            {
                diaCorrecto = dia > 0 && dia <= 31;
            }
            if (ano >= 0 && mesCorrecto && diaCorrecto)
            {
                fecha = true;
            }
            return fecha;
        }
        private void fechaBtn_Click(object sender, EventArgs e)
        {
            int dia;
            int mes;
            int ano;
            string texto = "La fecha introducida no es válida.";

            dia = int.Parse(txtDia.Text);
            mes = int.Parse(txtMes.Text);
            ano = int.Parse(txtAno.Text);

            if (fechaValida(dia, mes, ano) == true)
            {
                texto = "La fecha introducida es válida.";
            }
            MessageBox.Show(texto);
        }
    }
}

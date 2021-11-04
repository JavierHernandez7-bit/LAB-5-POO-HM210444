using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guia5_Ejemplo2_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool validarCampos()
        {
            //variable que verifica si algo ha sido validado
            bool validado = true;
            if (txtnombre.Text == "") //vefica que no quede vacío el campo
            {

                validado = false; //si está vacío validado es falso
                errorProvider1.SetError(txtnombre, "Ingresar nombre");
            }
            if (txtapellido.Text == "")
            {
                validado = false;
                //digo que verifico a txtapellido y si no cumple mando ese mensaje
                errorProvider1.SetError(txtapellido, "Ingrese apellido");
            }
            return validado;
        }
        private void BorrarMesaje()
        {
            //borra los mensajes para que no se muestren y pueda limpiar
            errorProvider1.SetError(txtnombre, "");
            errorProvider1.SetError(txtapellido, "");
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            //limpia cualquier mensaje de error de alguna corrida previa
            BorrarMesaje();
            //llamamos al método para validar campos, el de nombre y apellido
            if (dtpFechaNacimiento.Value > DateTime.Now)
            {
                errorProvider1.SetError(dtpFechaNacimiento, "Seleccione una fecha real");

            }
            else if  (validarCampos())
            {
                
                MessageBox.Show("Los datos se ingresaron correctamente");

                //verificamos la fecha de nacimiento que nos den
                //DateTimePicker se llama dtpFechaNacimiento
                DateTime fechaNacimiento = dtpFechaNacimiento.Value;
                //verificamos la fecha del sistema (solo calculamos con los años
                int anios = System.DateTime.Now.Year - fechaNacimiento.Year;
                /*verificamos aparte del año si ya pasamos la fecha de nacimiento de este año o nos
               faltan días*/
                if (System.DateTime.Now.Subtract(fechaNacimiento.AddYears(anios)).TotalDays < 0)
                {


                    //si nos faltan días para cumplir años al cálculo le resta uno
                    txtedad.Text = Convert.ToString(anios - 1);
                }
                else
                {
                    //si ya pasó nuestra fecha de nacimiento manda el valor correspondiente
                    txtedad.Text = Convert.ToString(anios);
                }
            }


        }

        private void txtedad_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}   

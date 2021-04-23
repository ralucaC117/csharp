using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using mpp_proiect_csharp.Services;
using mpp_proiect_csharp.Model;
using mpp_proiect_csharp.Persistance;
using Client;

namespace mpp_proiect_csharp
{
    public partial class MainForm : Form
    {
        public int IdOperator { get; set; }
        private Controller controller;
        public delegate void InvokeDelegate();
        public MainForm(Controller controller)
        {         
            InitializeComponent();
            this.controller = controller;
            controller.updateEvent += userUpdate;
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {           
            log4net.Config.XmlConfigurator.Configure();          
            dataGridViewRides.DataSource = controller.findAllRides();
            dataGridViewReservations.DataSource = controller.findAllReservations().Where(r => r.Operator.Equals(this.IdOperator)).ToList();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddRide_Click(object sender, EventArgs e)
        {
            String destination = textBoxDestination.Text;
            DateTime date = dateTimePicker1.Value;
            int hour = Convert.ToInt32(hourPicker.Value);
            int minutes = Convert.ToInt32(minutesPicker.Value);
            date.AddHours(hour);
            date.AddMinutes(minutes);
            try { controller.addRide(destination, date); }
            catch(Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
            /*dataGridViewRides.DataSource = controller.FindAllRides();*/



        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddRide_Click_1(object sender, EventArgs e)
        {
            String destination = textBoxDestination.Text;
            DateTime date = dateTimePicker1.Value;
            int hour = Convert.ToInt32(hourPicker.Value);
            int minutes = Convert.ToInt32(minutesPicker.Value);
            date.AddHours(hour);
            date.AddMinutes(minutes);
            try { controller.addRide(destination, date); }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
           /*dataGridViewRides.DataSource = Service.FindAllRides();*/
        }

        private void buttonBookReservation_Click(object sender, EventArgs e)
        {
           String destination = dataGridViewRides.SelectedRows[0].Cells[0].Value.ToString();
            int noOfSeatsBefore = Convert.ToInt32(dataGridViewRides.SelectedRows[0].Cells[2].Value);
            String dateTimeS = dataGridViewRides.SelectedRows[0].Cells[1].Value.ToString();
            DateTime dateTime = Convert.ToDateTime(dateTimeS);

            String clientName = textBoxClientName.Text;
            String clientPhoneNumber = textBoxClientPhoneNumber.Text;
            int idRide = Convert.ToInt32(dataGridViewRides.SelectedRows[0].Cells[3].Value);
            int noOfSeats = Convert.ToInt32(textBoxNoOfSeats.Text);

            Ride ride = new Ride(destination, dateTime);
            ride.Id = idRide;
            ride.AvailableSeats = noOfSeatsBefore - noOfSeats;
            controller.addReservation(this.IdOperator, idRide,  clientName, clientPhoneNumber, noOfSeats);
            controller.updateRide(ride);

           /* dataGridViewRides.DataSource = Service.FindAllRides();
            dataGridViewReservations.DataSource = Service.FindAllReservations().Where(r => r.Operator.Equals(this.IdOperator)).ToList();*/
        }

        private void buttonCancelReservation_Click(object sender, EventArgs e)
        {
            /*int idRide = Convert.ToInt32(dataGridViewReservations.SelectedRows[0].Cells[1].Value);
            int idReservation = Convert.ToInt32(dataGridViewReservations.SelectedRows[0].Cells[5].Value); 
            int selectedNoOfSeats = Convert.ToInt32(dataGridViewReservations.SelectedRows[0].Cells[4].Value);
            Ride ride = Service.findOneRide(idRide);
            ride.AvailableSeats += selectedNoOfSeats;
            Service.deleteReservation(idReservation);
            Service.updateRide(ride);

            dataGridViewRides.DataSource = Service.FindAllRides();
            dataGridViewReservations.DataSource = Service.FindAllReservations().Where(r => r.Operator.Equals(this.IdOperator)).ToList();*/
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        public void userUpdate(object sender, MyEventArguments e)
        {
            if (e.UserEventType == MyEvent.ADD_RIDE || e.UserEventType == MyEvent.ADD_RESERVATION)
            {
                this.BeginInvoke(new InvokeDelegate(update));
            }
        }

        public void update()
        {

            dataGridViewReservations.DataSource = controller.findAllReservations().Where(r => r.Operator.Equals(this.IdOperator)).ToList();
            dataGridViewRides.DataSource = controller.findAllRides();

        }

    }
}

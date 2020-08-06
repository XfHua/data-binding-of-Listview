using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App341
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = this;

            //Servico servico = User.Servicos.First();

            User.Servicos = new ObservableCollection<Servico>();

            LoadServicesList();

            LoadService();


        }

        private void LoadService()
        {

            Servico servico1 = new Servico("tipottt",0.2,0.5);
            Servico servico2 = new Servico("tipottt2", 0.2, 0.22);

            Servico servico3 = new Servico("tipottt3", 0.23, 0.333);

            User.Servicos.Add(servico1);
            User.Servicos.Add(servico2);
            User.Servicos.Add(servico3);

        }

        public void LoadServicesList()
        {
            ListViewServicos.RowHeight = 80;
           // ListViewServicos.HeightRequest = User.Servicos.Count() * 80;
            ListViewServicos.ItemsSource = User.Servicos;
        }
    }

    public class Servico
    {
        public string Tipo { get; set; }
        public double Margem { get; set; }

        public string MargemFormatada { get; set; }

        public double MargemUtilizada { get; set; }

        public string MargemUtilizadaFormatada { get; set; }

        public string MargemTotalFormatada { get; set; }

        public string Color { get; set; }

        public Servico(string tipo, double margem, double margemUtilizada)
        {
            this.Tipo = tipo;
            Margem = margem;
            MargemUtilizada = margemUtilizada;
            MargemFormatada = string.Format(new CultureInfo("pt-BR"), "{0:C}", margem);
            MargemUtilizadaFormatada = string.Format(new CultureInfo("pt-BR"), "{0:C}", margemUtilizada);
            MargemTotalFormatada = string.Format(new CultureInfo("pt-BR"), "{0:C}", margem + margemUtilizada);
        }
    }

    public static class User
    {
        public static ObservableCollection<Servico> Servicos { get; set; }
    }
}

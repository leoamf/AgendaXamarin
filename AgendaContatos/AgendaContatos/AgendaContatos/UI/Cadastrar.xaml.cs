using AgendaContatos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AgendaContatos.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastrar : ContentPage
    {
        private MainPage _mainPage;

        public Cadastrar(MainPage mainPage)
        {
            InitializeComponent();
            _mainPage = mainPage;

        }


        protected async Task Handle_ClickedAsync(object sender, System.EventArgs e)
        {
            Contato conato = new Contato
            {
                Nome = txtNome.Text,
                Telefone = txtTelefone.Text
            };
            App.BD.Insert(conato);
            App.Current.DataUltimoRegistroKey = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            await DisplayAlert("Sucesso", "Contato cadastrado com sucesso!", "Ok");
       
            _mainPage.CarregarLista();
            await Navigation.PopAsync(true);
        }

    }
}
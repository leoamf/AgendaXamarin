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
	public partial class Editar : ContentPage
	{
        private MainPage _mainPage;
        private Contato _contato = null;
		public Editar (Contato contato,MainPage mainPage)
		{
			InitializeComponent ();
            _contato = contato;
            _mainPage = mainPage;
            txtTelefone.Text = contato.Telefone;
            txtNome.Text = contato.Nome;
        }


        protected async Task Handle_ClickedAsync(object sender, System.EventArgs e)
        {
            Contato conato = new Contato
            {
                Id = _contato.Id,
                Nome = txtNome.Text,
                Telefone = txtTelefone.Text
            };

            App.BD.Update(conato);
            await DisplayAlert("Sucesso", "Contato salvo com sucesso!", "Ok");
            _mainPage.CarregarLista();
            await Navigation.PopAsync(true);
        }

    }
}
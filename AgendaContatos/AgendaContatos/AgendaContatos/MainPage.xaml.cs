using AgendaContatos.Dominio;
using AgendaContatos.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AgendaContatos
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
            CarregarLista(); 
        }
        public void CarregarLista()
        {
            var dadosTabela = App.BD.Table<Contato>() ; 
            contatos.ItemsSource = dadosTabela.OrderBy(x => x.Nome );
            txtDataUltimoCadastrato.Text ="Último Cadastro: " + App.Current.DataUltimoRegistroKey;
        }

        private async Task Handle_Delete(object sender, System.EventArgs e)
        {
            var viewCellSelected = sender as MenuItem; 
            var selecionado = viewCellSelected?.BindingContext as Contato; 
            var answer = await DisplayAlert("Deletar", "Deseja deletar o registro?", "Sim", "Não");
            if (answer)
            {
                App.BD.Delete(selecionado);
            }

            CarregarLista();
        }
         

        private async Task Cadastrar_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Cadastrar(this));
            
        }
         

        private async Task contatos_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            var selecionado = (Contato)e.SelectedItem;
            await Navigation.PushAsync(new Editar(selecionado, this));
            CarregarLista();
        }
    }
}

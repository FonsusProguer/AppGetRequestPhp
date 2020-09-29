using AppGetRequestPhp.Models;
using AppGetRequestPhp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppGetRequestPhp.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        WebApiClientService webApi = new WebApiClientService();

        private ObservableCollection<EmpleadoModel> listaEmpleados;
        public ObservableCollection<EmpleadoModel> ListaEmpleados
        {
            get { return listaEmpleados; }
            set { listaEmpleados = value; RaisePropetyChanged(); }
        }

        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; RaisePropetyChanged(); }
        }

        public async Task ConsultaListaEmpleadosGet()
        {
            string stParamsGet = $"IdEmpresa={Id}";

            ListaEmpleados = await webApi.executeRequestGet<ObservableCollection<EmpleadoModel>>(stParamsGet);
        }

        public ICommand ConsultaListaEmpleadosGetCommand { get; set; }


        public MainViewModel()
        {
            ConsultaListaEmpleadosGetCommand = new Command(async () => await ConsultaListaEmpleadosGet());
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Business;
using Entity;

namespace WpfSemana05
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            BPedido bPedido = null;
            try
            {
                bPedido = new BPedido();
                dgvPedido.ItemsSource = bPedido.GetPedidosEntreFechas(Convert.ToDateTime(txtFechaInicio.Text),
                                                                      Convert.ToDateTime(txtFechaFin.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                bPedido = null;
            }
        }

        private void dgvPedido_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void dgvPedido_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Pedido row = (Pedido)dgvPedido.SelectedItem;
            BDetallePedido bDetallePedido = null;
            try
            {
                bDetallePedido = new BDetallePedido();
                dgvDetallePedido.ItemsSource = bDetallePedido.GetDetallePedidos(row.IdPedido);
                txtTotal.Text = bDetallePedido.GetDetalleTotalPorId(row.IdPedido).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                bDetallePedido = null;
            }
        }
    }
}

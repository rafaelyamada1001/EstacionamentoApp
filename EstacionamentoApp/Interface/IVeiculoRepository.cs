using EstacionamentoApp.Management;

namespace EstacionamentoApp.Interface
{
    public interface IVeiculoRepository
    {
        void AdicionarVeiculo(string placa);
        void RemoverVeiculo(string placa);
        void ListarVeiculos();
        void VagasDesocupadas();

    }
}

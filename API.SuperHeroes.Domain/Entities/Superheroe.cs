using API.SuperHeroes.Domain.Entidade.Validacoes;

namespace API.SuperHeroes.Domain.Entidade
{
    public class Superheroe 
        : Base.Entidade<Superheroe>
    {
        public Superheroe()
             : base(new SuperheroeValidador())
        {

        }

        public int Id_superheroe { get; set; }
        public string Nm_superheroe { get; set; }
        public string Ds_superheroe { get; set; }
        public string St_ativo { get; set; }
        public byte[] Im_superheroe { get; set; }

        public override bool Validar()
        {
            return this.Validar(this);
        }
    }
}

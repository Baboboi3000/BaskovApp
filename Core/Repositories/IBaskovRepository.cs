using Core.Entities;

namespace Core.Repository;
 public interface IBaskovRepository
{
    void Add (Baskov baskov);
    List<Baskov> GetAll ();

}


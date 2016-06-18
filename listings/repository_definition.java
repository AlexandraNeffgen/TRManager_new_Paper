public interface FormRepository extends JpaRepository<Form,Integer>{	
	@Query("SELECT r from Form r where r.ID = ?1")
	Form findFormById(int id);
}
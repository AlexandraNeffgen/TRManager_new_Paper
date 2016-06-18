@Service
public class FormServiceImpl implements FormService{
	@Autowired
	private FormRepository repository;
	
	@Override
	public Form getFormById(int id){
		Form form = repository.findOne(id);
		
		if(form == null) return null;
		return repository.findFormById(id);
	}
}
@RestController
@RequestMapping(value = "/trmanager/form")
public class FormController {
	@Autowired
	private FormRepository repository;
	
	@RequestMapping(method = RequestMethod.GET)
	public List<Form> getAllForms(){
		List<Form> forms = repository.findAll();
		return forms;
	}
}
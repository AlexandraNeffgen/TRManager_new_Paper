@RestController
@RequestMapping(value = "/trmanager/form")
public class FormController {
	@Autowired
	private FormService service;
	
	@RequestMapping(method = RequestMethod.GET)
	public List<Form> getAllForms(){
		List<Form> forms = service.getAllForms();
		return forms;
	}
}
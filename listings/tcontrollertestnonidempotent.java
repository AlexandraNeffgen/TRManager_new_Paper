	@Test
	public void testAddTeacher() throws Exception{
		Teacher t = new Teacher(null, "TESTTEACHER", "TEST", "Herr");
		Teacher t_err = new Teacher(null, "TESTTEACHER2", null, "Herr");
		
		ObjectMapper mapper = new ObjectMapper();
		PrettyPrinter printer = new DefaultPrettyPrinter();
		ObjectWriter writer = mapper.writer().with(printer);
		String json = writer.writeValueAsString(t);
		String json_err = writer.writeValueAsString(t_err);
		
		MockHttpServletRequestBuilder postRequest = post("/trmanager/teacher/")
				.contentType(MediaType.APPLICATION_JSON)
				.content(json);
		ResultActions result;
		result = mvc.perform(postRequest);
		result.andDo(print());
		result.andExpect(status().isOk());
		
		postRequest = post("/trmanager/teacher")
						.contentType(MediaType.APPLICATION_JSON)
						.content(json_err);
		result = mvc.perform(postRequest);
		result.andDo(print());
		result.andExpect(status().isInternalServerError());	
	}
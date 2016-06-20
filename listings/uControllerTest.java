	@Test
	public void testAuthenticate() throws Exception{
		User u = repository.findOne(1);
		User u_err = new User(1,"test","test");
		ObjectMapper mapper = new ObjectMapper();
		PrettyPrinter printer = new DefaultPrettyPrinter();
		ObjectWriter writer = mapper.writer().with(printer);
		String json = writer.writeValueAsString(u);
		String json_err = writer.writeValueAsString(u_err);
		MockHttpServletRequestBuilder authRequest = post("/trmanager/auth/")
							.contentType(MediaType.APPLICATION_JSON)
							.content(json);
		MockHttpServletRequestBuilder authRequestErr = post("/trmanager/auth/")
				.contentType(MediaType.APPLICATION_JSON)
				.content(json_err);
		
		ResultActions result = mvc.perform(authRequest);
		result.andDo(print());
		result.andExpect(status().isOk());
		ResultActions result_err = mvc.perform(authRequestErr);
		result_err.andDo(print());
		result_err.andExpect(status().isUnauthorized());
	}
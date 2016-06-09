	@Test
	public void testGetTeacherById() throws Exception{
			MockHttpServletRequestBuilder getRequest = get("/trmanager/teacher/50000");
			ResultActions result = mvc.perform(getRequest);
			result.andExpect(status().isNotFound());
			getRequest = get("/trmanager/teacher/5");
			result = mvc.perform(getRequest);
			result.andDo(print());
			result.andExpect(status().isOk());
			
	}
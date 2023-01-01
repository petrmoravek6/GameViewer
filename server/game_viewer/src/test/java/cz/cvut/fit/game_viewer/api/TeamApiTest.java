package cz.cvut.fit.game_viewer.api;

import cz.cvut.fit.game_viewer.api.model.converter.*;
import cz.cvut.fit.game_viewer.business.TeamService;
import org.hamcrest.Matchers;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.AutoConfigureMockMvc;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.request.MockMvcRequestBuilders;
import org.springframework.test.web.servlet.result.MockMvcResultMatchers;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

@SpringBootTest
@AutoConfigureMockMvc
public class TeamApiTest {

  @Autowired
  MockMvc mvc;

  @Autowired
  TeamService teamService;

  @Autowired
  TeamToDtoConverter teamToDtoConverter;

  @Autowired
  TeamToEntityConverter teamToEntityConverter;

  Pattern numberPattern = Pattern.compile("\"id\":\\s*(\\d+)");

  @Test
  void postAndGet() throws Exception {

    var getAllBefore = mvc.perform(MockMvcRequestBuilders.get("/team"))
            .andExpect(MockMvcResultMatchers.status().isOk())
            .andReturn();
    var getAllBeforeResponse = getAllBefore.getResponse().getContentAsString();

    var post1 = mvc.perform(MockMvcRequestBuilders.post("/team").content("{\"id\": null, \"name\": \"test\", \"shortname\": \"tst\"}")
                    .contentType(MediaType.APPLICATION_JSON))
            .andExpect(MockMvcResultMatchers.status().isOk())
            .andExpect(MockMvcResultMatchers.jsonPath("$.name", Matchers.is("test")))
            .andExpect(MockMvcResultMatchers.jsonPath("$.shortname", Matchers.is("tst")))
            .andReturn();
    var post1Response = post1.getResponse().getContentAsString();
    Matcher matcher = numberPattern.matcher(post1Response);
    matcher.find();
    Long id1 = Long.parseLong(matcher.group(1));

    var post2 = mvc.perform(MockMvcRequestBuilders.post("/team").content("{\"id\": null, \"name\": \"test2\", \"shortname\": \"tst2\"}")
                    .contentType(MediaType.APPLICATION_JSON))
            .andExpect(MockMvcResultMatchers.status().isOk())
            .andExpect(MockMvcResultMatchers.jsonPath("$.name", Matchers.is("test2")))
            .andExpect(MockMvcResultMatchers.jsonPath("$.shortname", Matchers.is("tst2")))
            .andReturn();
    var post2Response = post2.getResponse().getContentAsString();
    matcher = numberPattern.matcher(post2Response);
    matcher.find();
    Long id2 = Long.parseLong(matcher.group(1));

    var getAllAfter = mvc.perform(MockMvcRequestBuilders.get("/team"))
            .andExpect(MockMvcResultMatchers.status().isOk())
            .andReturn();
    var getAllAfterResponse = getAllAfter.getResponse().getContentAsString();

    var getTeam1 = mvc.perform(MockMvcRequestBuilders.get(String.format("/team/%d", id1)))
            .andExpect(MockMvcResultMatchers.status().isOk())
            .andReturn();
    var getTeam1Response = getTeam1.getResponse().getContentAsString();

    var getTeam2 = mvc.perform(MockMvcRequestBuilders.get(String.format("/team/%d", id2)))
            .andExpect(MockMvcResultMatchers.status().isOk())
            .andReturn();
    var getTeam2Response = getTeam2.getResponse().getContentAsString();

    // get all response before posting doesn't contain entities with id posted after
    Assertions.assertFalse(getAllBeforeResponse.contains(String.format("\"id\":%d", id1)));
    Assertions.assertFalse(getAllBeforeResponse.contains(String.format("\"id\":%d", id2)));
    // get all response after posting includes posted ids
    Assertions.assertTrue(getAllAfterResponse.contains(String.format("\"id\":%d", id1)));
    Assertions.assertTrue(getAllAfterResponse.contains(String.format("\"id\":%d", id2)));
    Assertions.assertEquals(post1Response, getTeam1Response);
    Assertions.assertEquals(post2Response, getTeam2Response);
    // number of objects in the GET response before posting should be two less than after posting
    Assertions.assertEquals((getAllBeforeResponse.split("\"id\":")).length + 2,
                                     (getAllAfterResponse.split("\"id\":")).length);
  }

  @Test
  void getError() throws Exception {
    // get request for team that does not exist
    mvc.perform(MockMvcRequestBuilders.get("/team/4206661"))
            .andExpect(MockMvcResultMatchers.status().is4xxClientError());
  }

  @Test
  void postError() throws Exception {
    // posting new team
    var postSuccess = mvc.perform(MockMvcRequestBuilders.post("/team").content("{\"id\": null, \"name\": \"test\", \"shortname\": \"tst\"}")
                    .contentType(MediaType.APPLICATION_JSON))
            .andExpect(MockMvcResultMatchers.status().isOk())
            .andReturn();
    var postSuccessResponse = postSuccess.getResponse().getContentAsString();
    Matcher matcher = numberPattern.matcher(postSuccessResponse);
    matcher.find();
    Long id = Long.parseLong(matcher.group(1));

    // posting team with already existing id is error due to AbstractCrudService logic
    mvc.perform(MockMvcRequestBuilders.post("/team").content(String.format("{\"id\": %d, \"name\": \"test2\", \"shortname\": \"tst2\"}", id))
                    .contentType(MediaType.APPLICATION_JSON))
            .andExpect(MockMvcResultMatchers.status().is4xxClientError());
  }

  @Test
  void put() throws Exception {
    // creating new team
    var postSuccess = mvc.perform(MockMvcRequestBuilders
                    .post("/team").content("{\"id\": null, \"name\": \"CREATED\", \"shortname\": \"CTD\"}")
                    .contentType(MediaType.APPLICATION_JSON))
            .andExpect(MockMvcResultMatchers.status().isOk())
            .andReturn();
    var postSuccessResponse = postSuccess.getResponse().getContentAsString();
    Matcher matcher = numberPattern.matcher(postSuccessResponse);
    matcher.find();
    // ID of the new entity
    Long id = Long.parseLong(matcher.group(1));


    // we will use PUT method to update the entity
    mvc.perform(MockMvcRequestBuilders.put(String.format("/team/%d", id))
                    .content(String.format("{\"id\": %d, \"name\": \"UPDATED\", \"shortname\": \"UPD\"}", id))
                    .contentType(MediaType.APPLICATION_JSON))
                    .andExpect(MockMvcResultMatchers.status().isOk());


    // we will use GET method to read the entity and check that is really updated
    mvc.perform(MockMvcRequestBuilders.get(String.format("/team/%d", id)))
            .andExpect(MockMvcResultMatchers.status().isOk())
            .andExpect(MockMvcResultMatchers.jsonPath("$.id", Matchers.is(id.intValue())))
            .andExpect(MockMvcResultMatchers.jsonPath("$.name", Matchers.is("UPDATED")))
            .andExpect(MockMvcResultMatchers.jsonPath("$.shortname", Matchers.is("UPD")));
    // we will also check if the previous entity (previous state) is no longer in the DB
    var getAll = mvc.perform(MockMvcRequestBuilders.get("/team"))
            .andExpect(MockMvcResultMatchers.status().isOk())
            .andReturn();
    var getAllResponse = getAll.getResponse().getContentAsString();
    Assertions.assertFalse(getAllResponse.contains("\"name\":\"CREATED\""));
    // now we will do the same process and we will update the same entity with the only exception:
    // JSON string representing the entity will have different ID than the ID in the HTTP parameter
    // which is fine, because the ID in the parameter eventually defines the entity's ID
    mvc.perform(MockMvcRequestBuilders.put(String.format("/team/%d", id))
                    .content(String.format("{\"id\": %d, \"name\": \"UPDATED_2\", \"shortname\": \"UPD_2\"}", id + 420))
                    .contentType(MediaType.APPLICATION_JSON))
            .andExpect(MockMvcResultMatchers.status().isOk());
    // we will use GET method to read the entity and check that is really updated
    mvc.perform(MockMvcRequestBuilders.get(String.format("/team/%d", id)))
            .andExpect(MockMvcResultMatchers.status().isOk())
            .andExpect(MockMvcResultMatchers.jsonPath("$.id", Matchers.is(id.intValue())))
            .andExpect(MockMvcResultMatchers.jsonPath("$.name", Matchers.is("UPDATED_2")))
            .andExpect(MockMvcResultMatchers.jsonPath("$.shortname", Matchers.is("UPD_2")));
    // we will also check if the previous entity (previous state) is no longer in the DB
    var getAll2 = mvc.perform(MockMvcRequestBuilders.get("/team"))
            .andExpect(MockMvcResultMatchers.status().isOk())
            .andReturn();
    var getAll2Response = getAll2.getResponse().getContentAsString();
    Assertions.assertFalse(getAll2Response.contains("\"name\":\"UPDATED\""));
  }

  @Test
  void putError() throws Exception {
    // we will use PUT to update entity that is not present in the DB
    mvc.perform(MockMvcRequestBuilders.put("/team/6664202")
                    .content("{\"id\": 6664202, \"name\": \"asdasdas\", \"shortname\": \"asd\"}")
                    .contentType(MediaType.APPLICATION_JSON))
            .andExpect(MockMvcResultMatchers.status().is4xxClientError());
  }

  @Test
  void delete() throws Exception {
    // creating new team
    var postSuccess = mvc.perform(MockMvcRequestBuilders
                    .post("/team").content("{\"id\": null, \"name\": \"sample\", \"shortname\": \"smp\"}")
                    .contentType(MediaType.APPLICATION_JSON))
            .andExpect(MockMvcResultMatchers.status().isOk())
            .andReturn();
    var postSuccessResponse = postSuccess.getResponse().getContentAsString();
    Matcher matcher = numberPattern.matcher(postSuccessResponse);
    matcher.find();
    // ID of the new entity
    Long id = Long.parseLong(matcher.group(1));


    // deleting entity that is present in the DB
    mvc.perform(MockMvcRequestBuilders.delete(String.format("/team/%d", id)))
            .andExpect(MockMvcResultMatchers.status().isOk());


    // entity should no longer be present on the server
    mvc.perform(MockMvcRequestBuilders.get(String.format("/team/%d", id)))
            .andExpect(MockMvcResultMatchers.status().is4xxClientError());


    // deleting entity that is NOT present in the DB (also should return 2xx success code)
    mvc.perform(MockMvcRequestBuilders.delete(String.format("/team/%d", id)))
            .andExpect(MockMvcResultMatchers.status().isOk());
  }
}

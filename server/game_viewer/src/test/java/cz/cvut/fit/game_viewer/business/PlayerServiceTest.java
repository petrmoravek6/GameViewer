package cz.cvut.fit.game_viewer.business;

import cz.cvut.fit.game_viewer.dao.player.PlayerRepository;
import cz.cvut.fit.game_viewer.domain.match.AgeLimit;
import cz.cvut.fit.game_viewer.domain.match.Match;
import cz.cvut.fit.game_viewer.domain.player.Player;
import cz.cvut.fit.game_viewer.domain.player.PlayerPosition;
import cz.cvut.fit.game_viewer.domain.team.Team;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.mockito.Mockito;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.boot.test.mock.mockito.MockBean;

import java.time.LocalDate;
import java.util.Collections;
import java.util.List;
import java.util.NoSuchElementException;
import java.util.Optional;

@SpringBootTest
public class PlayerServiceTest {

  @Autowired
  PlayerService playerService;

  @MockBean
  PlayerRepository playerRepository;

  @Test
  void getAllTeamsPlayerWonAgainst() {

    Team team1 = new Team(1L, "FK Praha", "FKP");
    Team team2 = new Team(2L, "FK Brno", "FKB");
    Team team3 = new Team(3L, "Chelsea", "CFC");
    Team team4 = new Team(4L, "Liverpool", "LIV");


    Player player1 = new Player(123L, "Jan Novák", LocalDate.of(2000, 1, 17),
            PlayerPosition.Attacker, team1, Collections.emptyList());
    Player dummyPlayer = new Player(124L, "Mr. Nobody", LocalDate.of(2000, 1, 17),
            PlayerPosition.Attacker, team2, Collections.emptyList());
    Player player2 = new Player(125L, "Petr Novotný", LocalDate.of(1999, 1, 17),
            PlayerPosition.Defender, team3, Collections.emptyList());
    Player player3 = new Player(126L, "Petr Moravek", LocalDate.of(1988, 1, 10),
            PlayerPosition.Goalkeeper, team4, Collections.emptyList());

    // player1 won against team2
    Match match1 = new Match(1000L, 1, 0, AgeLimit.Senior, LocalDate.of(2020, 11, 20),
            team1, team2, List.of(player1, dummyPlayer));
    // player1 won against team3, player2 lost
    Match match2 = new Match(1001L, 0, 5, AgeLimit.Senior, LocalDate.of(2021, 11, 20),
            team3, team1, List.of(player1, player2));
    Match match3 = new Match(1002L, 1, 1, AgeLimit.Senior, LocalDate.of(2020, 10, 20),
            team1, team4, List.of(player1));
    Match match4 = new Match(1003L, 0, 3, AgeLimit.Senior, LocalDate.of(2021, 9, 20),
            team1, team4, List.of(player1));
    Match match5 = new Match(1004L, 6, 3, AgeLimit.Senior, LocalDate.of(2021, 9, 29),
            team4, team1, List.of(player1));
    // player3 won against team2
    Match match6 = new Match(1005L, 5, 3, AgeLimit.Senior, LocalDate.of(2018, 9, 23),
            team2, team4, List.of(dummyPlayer, player3));
    // player3 won against team2
    Match match7 = new Match(1006L, 7, 3, AgeLimit.Senior, LocalDate.of(2021, 9, 30),
            team4, team2, List.of(player3, dummyPlayer));

    player1.setMatchesPlayed(List.of(match1, match2, match3, match4, match5));
    player2.setMatchesPlayed(List.of(match2));
    dummyPlayer.setMatchesPlayed(List.of(match1, match2, match7));
    player3.setMatchesPlayed(List.of(match6, match7));

    Mockito.when(playerRepository.findById(123L)).thenReturn(Optional.of(player1));
    Mockito.when(playerRepository.findById(125L)).thenReturn(Optional.of(player2));
    Mockito.when(playerRepository.findById(126L)).thenReturn(Optional.of(player3));
    // repository doesn't know dummyPlayer
    Mockito.when(playerRepository.findById(124L)).thenReturn(Optional.empty());


    var res1 = playerService.getAllTeamsPlayerWonAgainst(123L);
    var res2 = playerService.getAllTeamsPlayerWonAgainst(125L);
    var res3 = playerService.getAllTeamsPlayerWonAgainst(126L);


    Assertions.assertEquals(2, res1.size());
    Assertions.assertTrue(res1.contains(team2));
    Assertions.assertTrue(res1.contains(team3));
    Assertions.assertEquals(0, res2.size());
    Assertions.assertEquals(1, res3.size());
    Assertions.assertTrue(res3.contains(team2));
    Assertions.assertThrows(NoSuchElementException.class, () -> playerService.getAllTeamsPlayerWonAgainst(124L));
  }

}

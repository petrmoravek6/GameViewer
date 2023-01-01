package cz.cvut.fit.game_viewer.api.dao;

import cz.cvut.fit.game_viewer.dao.match.MatchRepository;
import cz.cvut.fit.game_viewer.dao.player.PlayerRepository;
import cz.cvut.fit.game_viewer.dao.team.TeamRepository;
import cz.cvut.fit.game_viewer.domain.match.AgeLimit;
import cz.cvut.fit.game_viewer.domain.match.Match;
import cz.cvut.fit.game_viewer.domain.player.Player;
import cz.cvut.fit.game_viewer.domain.player.PlayerPosition;
import cz.cvut.fit.game_viewer.domain.team.Team;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

import java.time.LocalDate;
import java.util.List;

@SpringBootTest
public class RepositoryBindingTest {

  @Autowired
  MatchRepository matchRepository;

  @Autowired
  TeamRepository teamRepository;

  @Autowired
  PlayerRepository playerRepository;

  @Test
  void matchParticipants_playerMatchesPlayed() {
    Team team1 = teamRepository.save(new Team(null, "Chelsea", "CFC"));
    Team team2 = teamRepository.save(new Team(null, "Liverpool", "LIV"));
    Team team3 = teamRepository.save(new Team(null, "Newcastle", "NCS"));

    Player player1 = playerRepository.save(new Player(null, "Jan Novak",
            LocalDate.of(2000, 1, 1), PlayerPosition.Attacker, team1, List.of()));
    Player player2 = playerRepository.save(new Player(null, "Karel Svoboda",
            LocalDate.of(2004, 1, 1), PlayerPosition.Defender, team1, List.of()));
    Player player3 = playerRepository.save(new Player(null, "Petr Moravek",
            LocalDate.of(1999, 1, 1), PlayerPosition.Goalkeeper, team2, List.of()));
    Player player4 = playerRepository.save(new Player(null, "Lukas Nemecek",
            LocalDate.of(2001, 1, 1), PlayerPosition.Unknown, team2, List.of()));
    Player player5 = playerRepository.save(new Player(null, "Ondrej Peterka",
            LocalDate.of(1980, 1, 1), PlayerPosition.Midfielder, team3, List.of()));


    // match1 participants: player1, player2, player3
    Match match1 = matchRepository.save(new Match(null, 2, 2, AgeLimit.Senior,
            LocalDate.of(2022, 1, 1), team1, team2, List.of(player1, player2, player3)));
    // match2 participants: player2
    Match match2 = matchRepository.save(new Match(null, 1, 1, AgeLimit.U21,
            LocalDate.of(2022, 10, 1), team2, team1, List.of(player2)));
    // match3 participants: player1
    Match match3 = matchRepository.save(new Match(null, 1, 1, AgeLimit.Senior,
            LocalDate.of(2022, 8, 1), team2, team1, List.of(player1)));
    // match4 participants: player3
    Match match4 = matchRepository.save(new Match(null, 0, 0, AgeLimit.Senior,
            LocalDate.of(2022, 10, 20), team2, team1, List.of(player3)));
    // match5 participants: player2, player3
    Match match5 = matchRepository.save(new Match(null, 6, 0, AgeLimit.Senior,
            LocalDate.of(2022, 7, 12), team1, team2, List.of(player2, player3)));

    Player p1 = playerRepository.findById(player1.getId()).get();
    Player p2 = playerRepository.findById(player2.getId()).get();
    Player p3 = playerRepository.findById(player3.getId()).get();
    Player p4 = playerRepository.findById(player4.getId()).get();
    Player p5 = playerRepository.findById(player5.getId()).get();


    Assertions.assertEquals(2, p1.getMatchesPlayed().size());
    Assertions.assertTrue(p1.getMatchesPlayed().contains(match1));
    Assertions.assertTrue(p1.getMatchesPlayed().contains(match3));
    Assertions.assertEquals(3, p2.getMatchesPlayed().size());
    Assertions.assertTrue(p2.getMatchesPlayed().contains(match1));
    Assertions.assertTrue(p2.getMatchesPlayed().contains(match2));
    Assertions.assertTrue(p2.getMatchesPlayed().contains(match5));
    Assertions.assertEquals(3, p3.getMatchesPlayed().size());
    Assertions.assertTrue(p3.getMatchesPlayed().contains(match1));
    Assertions.assertTrue(p3.getMatchesPlayed().contains(match4));
    Assertions.assertTrue(p3.getMatchesPlayed().contains(match5));
    Assertions.assertEquals(0, p4.getMatchesPlayed().size());
    Assertions.assertEquals(0, p5.getMatchesPlayed().size());
  }
}

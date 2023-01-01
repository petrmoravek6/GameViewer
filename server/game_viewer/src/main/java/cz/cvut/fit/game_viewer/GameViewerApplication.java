package cz.cvut.fit.game_viewer;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.autoconfigure.jdbc.DataSourceAutoConfiguration;
//@SpringBootApplication(exclude = {DataSourceAutoConfiguration.class })
@SpringBootApplication
public class GameViewerApplication {

	public static void main(String[] args) {
		SpringApplication.run(GameViewerApplication.class, args);
	}

}

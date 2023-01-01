package cz.cvut.fit.game_viewer.api.controller;

import cz.cvut.fit.game_viewer.business.AbstractCrudService;
import cz.cvut.fit.game_viewer.business.EntityStateException;
import cz.cvut.fit.game_viewer.domain.DomainEntity;
import org.springframework.dao.EmptyResultDataAccessException;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Collection;
import java.util.function.Function;
import java.util.stream.StreamSupport;

public abstract class AbstractCrudController<Ent extends DomainEntity<ID>, Dto extends DomainEntity<ID>, ID> {
    protected AbstractCrudService<Ent, ID> service;
    protected Function<Ent, Dto> toDtoConverter;
    protected Function<Dto, Ent> toEntityConverter;

    public AbstractCrudController(AbstractCrudService<Ent, ID> service, Function<Ent, Dto> toDtoConverter, Function<Dto, Ent> toEntityConverter) {
        this.service = service;
        this.toDtoConverter = toDtoConverter;
        this.toEntityConverter = toEntityConverter;
    }


    @PostMapping
    public ResponseEntity<Dto> create(@RequestBody Dto e) {
        try {
            return ResponseEntity.ok(toDtoConverter.apply(service.create(toEntityConverter.apply(e))));
        }
        // entity with given id already exists
        catch (EntityStateException exception) {
            // return 400
            return ResponseEntity.badRequest().build();
        }
    }

    public Collection<Dto> readAll() {
        return StreamSupport.stream(service.readAll().spliterator(), false).map(toDtoConverter).toList();
    }

    @GetMapping("/{id}")
    public ResponseEntity<Dto> readOne(@PathVariable ID id) {
        var res = service.readById(id);
        if (res.isPresent())
            // return 200 with new entity included in the response message
            return ResponseEntity.ok(toDtoConverter.apply(res.get()));
        else
            // return 404
            return ResponseEntity.notFound().build();
    }

    @PutMapping("/{id}")
    public ResponseEntity<?> update(@RequestBody Dto e, @PathVariable ID id) {
        // first we set entity's ID to ID that is represented as parameter in http request
        e.setId(id);
        try {
            // update the entity
            service.update(toEntityConverter.apply(e));
            // return 200
            return ResponseEntity.ok().build();
        }
        // entity with given id does not exist, in our logic that is considered as an error
        catch (EntityStateException ignored) {
            // return 404
            return ResponseEntity.notFound().build();
        }
    }

    @DeleteMapping("/{id}")
    public void delete(@PathVariable ID id) {
        try {
            service.deleteById(id);
        }
        // when entity with given ID is not present, just ignore the request
        catch (EmptyResultDataAccessException ignored) {
        }
    }
}

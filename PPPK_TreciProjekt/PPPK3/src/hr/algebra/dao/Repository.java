/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.dao;

import java.util.List;

/**
 *
 * @author Teodor
 */
public interface Repository<T> {
    
//    int addPerson(Person data) throws Exception;
//    void updatePerson(Person data) throws Exception;
//    void deletePerson(Person person) throws Exception;
//    Person getPerson(int id) throws Exception;
//    List<Person> getPeople() throws Exception;
    
    int add(T data) throws Exception;
    void update(T data) throws Exception;
    void delete (T entity) throws Exception;
    T select(int id) throws Exception;
    List<T> selectAll() throws Exception;
    
    default void release() throws Exception{ }
}

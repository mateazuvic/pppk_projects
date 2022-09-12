/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.model;

import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author Teodor
 */
@Entity
@Table(name = "TVShow")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "TVShow.findAll", query = "SELECT t FROM TVShow t")
    , @NamedQuery(name = "TVShow.findByIDShow", query = "SELECT t FROM TVShow t WHERE t.iDShow = :iDShow")
    , @NamedQuery(name = "TVShow.findByName", query = "SELECT t FROM TVShow t WHERE t.name = :name")
    , @NamedQuery(name = "TVShow.findByRating", query = "SELECT t FROM TVShow t WHERE t.rating = :rating")})
public class TVShow implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @GeneratedValue(strategy = GenerationType.AUTO)
    @Column(name = "IDShow")
    private Integer iDShow;
    @Basic(optional = false)
    @Column(name = "Name")
    private String name;
    @Basic(optional = false)
    @Column(name = "Rating")
    private int rating;
    @JoinColumn(name = "PersonID", referencedColumnName = "IDPerson")
    @ManyToOne
    private Person personID;

    public TVShow() {
    }
    
    public TVShow(TVShow data) {
        updateDetails(data);
    }

    public TVShow(Integer iDShow) {
        this.iDShow = iDShow;
    }

    public TVShow(Integer iDShow, String name, int rating) {
        this.iDShow = iDShow;
        this.name = name;
        this.rating = rating;
    }

    public Integer getIDShow() {
        return iDShow;
    }

    public void setIDShow(Integer iDShow) {
        this.iDShow = iDShow;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getRating() {
        return rating;
    }

    public void setRating(int rating) {
        this.rating = rating;
    }

    public Person getPersonID() {
        return personID;
    }

    public void setPersonID(Person personID) {
        this.personID = personID;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (iDShow != null ? iDShow.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof TVShow)) {
            return false;
        }
        TVShow other = (TVShow) object;
        if ((this.iDShow == null && other.iDShow != null) || (this.iDShow != null && !this.iDShow.equals(other.iDShow))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "hr.algebra.model.TVShow[ iDShow=" + iDShow + " ]";
    }

    public void updateDetails(TVShow data) {
        this.name = data.getName();
        this.rating = data.getRating();
        this.personID = data.getPersonID();
        
    }
    
}

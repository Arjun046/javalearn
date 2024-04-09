package com.practice.SpringJdbC.Repo;

import com.practice.SpringJdbC.Model.Employee;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.RowMapper;
import org.springframework.stereotype.Repository;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

@Repository
public class EmployeeRepository {

    @Autowired
    private JdbcTemplate jdbcTemplate;

    public JdbcTemplate getJdbcTemplate() {
        return jdbcTemplate;
    }

    @Autowired
    public void setJdbcTemplate(JdbcTemplate jdbcTemplate) {
        this.jdbcTemplate = jdbcTemplate;
    }

    public void save(Employee employee) {
        String sql="insert into employee(id,firstName,lastName,Designation,Address,ContactNo) values(?,?,?,?,?,?)";
        int rows=jdbcTemplate.update(sql,employee.getId(),employee.getFirstName(),employee.getLastName(),employee.getDesignation(),employee.getAddress(),employee.getContactNo());
        System.out.println(rows + "Added");
    }
    public List<Employee> findAll(){
        String sql="Select * from employee";
        RowMapper<Employee> rowMapper=new RowMapper<Employee>() {
            @Override
            public Employee mapRow(ResultSet rs, int rowNum) throws SQLException {
                Employee emp=new Employee();
                emp.setId(rs.getInt(1));
                emp.setFirstName(rs.getString(2));
                emp.setLastName(rs.getString(3));
                emp.setDesignation(rs.getString(4));
                emp.setAddress(rs.getString(5));
                emp.setContactNo(rs.getString(6));
                return emp;
            }
        };

        List<Employee> employees=jdbcTemplate.query(sql,rowMapper);
        return  employees;
    }
}

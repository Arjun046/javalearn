package com.practice.SpringJdbC;

import com.practice.SpringJdbC.Model.Employee;
import com.practice.SpringJdbC.Repo.EmployeeRepository;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.ApplicationContext;

@SpringBootApplication
public class SpringJdbCApplication {

	public static void main(String[] args) {
		ApplicationContext context=SpringApplication.run(SpringJdbCApplication.class, args);

		Employee employee=context.getBean(Employee.class);
		employee.setId(11);
		employee.setFirstName("Arjun");
		employee.setLastName("Suthar");
		employee.setDesignation("Software Developer");
		employee.setAddress("Ahmedabad");
		employee.setContactNo("7732909436");

		EmployeeRepository employeeRepository=context.getBean(EmployeeRepository.class);
		employeeRepository.save(employee);
		System.out.println(employeeRepository.findAll());
	}

}

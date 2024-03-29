﻿using HRIS.Application.Common.Interfaces.Application;
using HRIS.Application.Common.Interfaces.Repositories;
using HRIS.Domain.Entities;
using HRIS.Domain.Enums;
using HRIS.Domain.ViewModels;
using HRIS.Infrastructure.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Infrastructure.Repositories
{
    public class EmployeeRepository : GenericRepositoryAsync<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public EmployeeRepository(ApplicationDBContext dbContext, IDateTime dateTimeService) : base(dbContext, dateTimeService)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployees()
        {
            var data = await (from emp in _dbContext.Employees
                              where emp.IsDeleted == false
                              join dep in _dbContext.Departments on emp.Department.Code equals dep.Code
                              where dep.IsDeleted == false
                              join sec in _dbContext.DepartmentSections
                              on new { A = emp.Department.Code, B = emp.DepartmentSectionCode }
                              equals new { A = sec.DepartmentCode, B = sec.Code }
                              where sec.IsDeleted == false
                              select new
                              {
                                  emp.BatchNo,
                                  emp.SerialID,
                                  emp.EmpID,
                                  emp.LastName,
                                  emp.FirstName,
                                  emp.MiddleName,
                                  DepartmentCode = dep.Code,
                                  DepartmentName = dep.Description,
                                  SectionCode = sec.Code,
                                  SectionName = sec.Description
                              }
                       ).Distinct().ToListAsync();

            var _result = data.Select(x => new EmployeeModel
            {
                BatchNo = x.BatchNo,
                SerialID = x.SerialID,
                EmpID = x.EmpID,
                LastName = x.LastName,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                DepartmentDetails = new DepartmentModel
                {
                    Code = x.DepartmentCode,
                    Description = x.DepartmentName
                },
                DepartmentSectionDetails = new DepartmentSectionModel
                {
                    Code = x.SectionCode,
                    Description = x.SectionName,
                    DepartmentCode = x.DepartmentCode
                }
            });

            return _result;
        }

        public async Task<EmployeeModel> GetEmployeeByID(string empid)
        {
            var data = (from emp in _dbContext.Employees where emp.IsDeleted == false
                        join dep in _dbContext.Departments on emp.Department.Code equals dep.Code
                        where dep.IsDeleted == false
                        join sec in _dbContext.DepartmentSections
                        on new { A = emp.Department.Code, B = emp.DepartmentSectionCode }
                        equals new { A = sec.DepartmentCode, B = sec.Code }
                        where sec.IsDeleted == false
                        select new
                        {
                            emp.BatchNo,
                            emp.SerialID,
                            emp.EmpID,
                            emp.LastName,
                            emp.FirstName,
                            emp.MiddleName,
                            DepartmentCode = dep.Code,
                            DepartmentName = dep.Description,
                            SectionCode = sec.Code,
                            SectionName = sec.Description
                        }
                       ).Where(x => x.EmpID == empid).FirstOrDefault();


            var _result = new EmployeeModel
            {
                BatchNo = data.BatchNo,
                SerialID = data.SerialID,
                EmpID = data.EmpID,
                LastName = data.LastName,
                FirstName = data.FirstName,
                MiddleName = data.MiddleName,
                DepartmentDetails = new DepartmentModel
                {
                    Code = data.DepartmentCode,
                    Description = data.DepartmentName
                },
                DepartmentSectionDetails = new DepartmentSectionModel
                {
                    Code = data.SectionCode,
                    Description = data.SectionName,
                    DepartmentCode = data.DepartmentCode
                }
            };

            return await Task.FromResult(_result);
        }

        public async Task Validate(Employee entity, CRUDType cRUDType)
        {
            entity.ValidateExists(_dbContext.Employees, cRUDType);
        }

        public override async Task<Employee> AddAsync(Employee entity)
        {
            try
            {
                var _result = await base.AddAsync(entity);
                return _result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override async Task UpdateAsync(Employee entity)
        {
            await base.UpdateAsync(entity);
        }

        public async Task<Employee> GetEmployeeByEmpID(string empid)
        {
            var _result = await _dbContext.Employees.Where(w => w.EmpID == empid && w.IsDeleted == false).FirstOrDefaultAsync();

            return _result;
        }

        public async Task<Employee> FullDeleteEmployee(string empid)
        {
            var data = await _dbContext.Employees.FindAsync(empid);

            _dbContext.Employees.Remove(data);
            
            await _dbContext.SaveChangesAsync();
            
            return data;

        }
    }
}

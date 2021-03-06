﻿using Promact.Oauth.Server.Models;
using Promact.Oauth.Server.Models.ApplicationClasses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promact.Oauth.Server.Repository.ProjectsRepository
{
    public interface IProjectRepository
    {
       
        /// <summary>
        /// Adds new project in the database
        /// </summary>
        /// <param name="newProject">project that need to be added</param>
        /// <param name="createdBy">Login User Id</param>
        /// <returns>project id of newly created project</returns>
        Task<int> AddProjectAsync(ProjectAc newProject,string createdBy);

        /// <summary>
        ///This method to add user id and project id in userproject table
        /// </summary>
        /// <param name="newProjectUser">projectuser object</param>
        Task AddUserProjectAsync(ProjectUser newUserProject);

        /// <summary>
        /// This method getting the list of all projects
        /// </summary>
        /// <returns>list of projects</returns>
        Task<IEnumerable<ProjectAc>> GetAllProjectsAsync();

        /// <summary>
        /// Get the Project details by project id. 
        /// </summary>
        /// <param name="id">project id</param> 
        /// <returns></returns>Project and User/Users infromation 
        Task<ProjectAc> GetProjectByIdAsync(int id);

        /// <summary>
        /// This method to update project information 
        /// </summary>
        /// <param name="id">project id</param> 
        /// <param name="editProject">updated project object</param> 
        /// <param name="updatedBy">passed id of user who has update this project</param>
        /// <returns>project id</returns>
        Task<int> EditProjectAsync(int id,ProjectAc editProject,string updatedBy);

        /// <summary>
        /// this method to check Project and SlackChannelName is already exists or not 
        /// </summary>
        /// <param name="project">projectAc object</param> 
        /// <returns>projectAc object</returns>
        Task<ProjectAc> CheckDuplicateProjectAsync(ProjectAc project);

        /// <summary>
        /// Method to return the project details of the given slack channel name - JJ
        /// </summary>
        /// <param name="slackChannelName">passed slack channel name</param>
        /// <returns>object of project</returns>
        Task<ProjectAc> GetProjectBySlackChannelNameAsync(string slackChannelName);

        /// <summary>
        /// This method to return all project for specific user
        /// </summary>
        /// <param name="userId">passed login user id</param>
        /// <returns>project information</returns>
        Task<IEnumerable<ProjectAc>> GetAllProjectForUserAsync(string userId);

        /// <summary>
        /// Method to return list of projects along with the users and teamleader in a project
        /// </summary>
        /// <returns>List of projects along with users</returns>
        Task<IList<ProjectAc>> GetProjectsWithUsersAsync();

        /// <summary>
        /// Method to return project details by using projectId - GA
        /// </summary>
        /// <param name="projectId">passed project Id</param>
        /// <returns>project details along with users</returns>
        Task<ProjectAc> GetProjectDetailsAsync(int projectId);

    }
}

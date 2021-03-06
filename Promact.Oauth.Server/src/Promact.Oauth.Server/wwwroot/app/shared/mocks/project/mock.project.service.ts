﻿import { Injectable } from '@angular/core';
import { ProjectModel } from "../../../project/project.model";
import { UserModel } from "../../../users/user.model";

@Injectable()
export class MockProjectService {
    projects: Array<ProjectModel> = new Array<ProjectModel>();
    constructor() {
        let mockProject = new ProjectModel();
        mockProject.Name = "slack1";
        mockProject.SlackChannelName = "slack.test";
        this.projects.push(mockProject);
    }
    getProjects() {
        return Promise.resolve(this.projects);
    }
    addProject(projectModel: ProjectModel) {
        projectModel.SlackChannelName = null;
        return Promise.resolve(projectModel);
    }
    editProject(projectModel: ProjectModel) {
        projectModel.SlackChannelName = null;
        return Promise.resolve(projectModel);
    }
    getUsers() {
        let mockUser = new UserModel();
        mockUser.FirstName = "Ronak";
        mockUser.LastName = "Shah";
        mockUser.Email = "rshah@Promactinfo.com";
        mockUser.IsActive = true;
        let mockList = new Array<UserModel>();
        return Promise.resolve(mockUser);
    }

    getProject(Id: number) {
        let mockProject = new MockProjects(Id);
        if (Id === 1) {
            mockProject.Name = "Project";
            mockProject.SlackChannelName = "Slack Channel";
            let mockUser = new UserModel();
            mockUser.FirstName = "Ronakfdfas";
            mockUser.LastName = "Shahfdsaf";
            mockUser.Email = "rshah@Promactinfofdsfs.com";
            mockUser.IsActive = true;
            mockUser.Id = "3";
            let mockList = new Array<UserModel>();
            mockList.push(mockUser);
            mockProject.ApplicationUsers = mockList;
            mockProject.TeamLeaderId = "2";
            mockProject.TeamLeader = mockUser;
            return Promise.resolve(mockProject);
        }
    }

}


class MockProjects extends ProjectModel {

    constructor(id: number) {
        super();
        this.Id = id;
    }

}
class MockProject extends ProjectModel {

    constructor() {
        super();

    }
}
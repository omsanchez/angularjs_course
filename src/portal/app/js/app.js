'use strict';

angular.module('taskApp', [
	'ui.router',
  'taskApp.controllers',
  'taskApp.filters',
  'taskApp.directives'

])
.config(function($stateProvider, $urlRouterProvider) {
	
	// For unmatch url, we set an default redirect
	$urlRouterProvider.otherwise("/taskList");

	$stateProvider
		.state('taskList' , {
			url:'/taskList',
			templateUrl: 'partials/tasklist.html'
		})
		.state('userList' , {
			url:'/userList',
			templateUrl: 'partials/userlist.html'
		})})

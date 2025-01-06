import axiosInstance from "../data/axiosInstance";
import Task from "../models/task";
import PaginatedResponse from "../models/paginate";

const BASE_URL = "/tasks";

const TaskService = {
  getAllTasks: async (page: number, pageSize: number): Promise<PaginatedResponse<Task>> => {
    const response = await axiosInstance.get<PaginatedResponse<Task>>(BASE_URL, {
      params: { currentPage: page, pageSize },
    });
    return response.data;
  },

  createTask: async (task: Partial<Task>): Promise<Task> => {
    const response = await axiosInstance.post<Task>(BASE_URL, task);
    return response.data;
  },
};

export default TaskService;
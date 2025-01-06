import { useEffect, useState } from 'react'
import TaskService from "./services/taskService";
import Task from "./models/task";
import {
  Card,
  CardHeader,
  CardTitle,
  CardContent,
  CardFooter,
} from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import { Textarea } from "@/components/ui/textarea";
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from './components/ui/table';
import { XCircleIcon } from '@heroicons/react/16/solid';
import { CheckCircleIcon } from '@heroicons/react/16/solid';
import { Checkbox } from './components/ui/checkbox';

function App() {
  const [tasks, setTasks] = useState<Task[]>([]);
  const [newTask, setNewTask] = useState({ name: "", description: "", isCompleted: false });
  const [currentPage, setCurrentPage] = useState(1);
  const [totalPages, setTotalPages] = useState(1);
  const pageSize = 5;

  const fetchTasks = async (page: number) => {
    try {
      const data = await TaskService.getAllTasks(page, pageSize);

      setTasks(data.data);
      setTotalPages(data.totalPages);
    } catch (error) {
      console.error("Failed to fetch tasks:", error);
    }
  };

  const createTask = async () => {
    try {
      const createdTask = await TaskService.createTask(newTask);
      setTasks([...tasks, createdTask]);
      setNewTask({ name: "", description: "", isCompleted: false });
      fetchTasks(currentPage);
    } catch (error) {
      console.error("Failed to create task:", error);
    }
  };

  useEffect(() => {
    fetchTasks(currentPage);
  }, [currentPage]);

  return (
    <div className="min-h-screen bg-gray-50 flex items-center justify-center p-6">
      <Card className="w-full max-w-3xl">
        <CardHeader>
          <CardTitle className="text-center text-2xl font-bold">
            Task Tracker
          </CardTitle>
        </CardHeader>
        <CardContent>
          <div className="mb-6">
            <Input
              placeholder="Task name"
              value={newTask.name}
              onChange={(e) =>
                setNewTask({ ...newTask, name: e.target.value })
              }
              className="mb-3"
            />
            <Textarea
              placeholder="Task description"
              value={newTask.description}
              onChange={(e) =>
                setNewTask({ ...newTask, description: e.target.value })
              }
            />
            <div className="flex items-center space-x-2">
              <Checkbox
                checked={newTask.isCompleted || false}
                onCheckedChange={(checked) =>
                  setNewTask({ ...newTask, isCompleted: !!checked })
                }
                className="rounded focus:ring focus:ring-blue-400"
              />
              <label className="text-gray-700">Mark as Completed</label>
            </div>
          </div>
          <Button onClick={createTask} className="w-full">
            Add Task
          </Button>
        </CardContent>
        <CardContent>
          <Table className="w-full">
            <TableHeader>
              <TableRow>
                <TableHead className="text-left">Task Name</TableHead>
                <TableHead className="text-left">Description</TableHead>
                <TableHead className="text-left">Completed?</TableHead>
              </TableRow>
            </TableHeader>
            <TableBody>
              {tasks.map((task) => (
                <TableRow key={task.id}>
                  <TableCell className="font-medium">{task.name}</TableCell>
                  <TableCell className="text-gray-600">{task.description}</TableCell>
                  <TableCell className="text-gray-600 flex items-center justify-center">
                    {task.isCompleted ? (
                      <CheckCircleIcon className="w-6 h-6 text-green-500" />
                    ) : (
                      <XCircleIcon className="w-6 h-6 text-red-500" />
                    )}
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </CardContent>
        <CardFooter className="flex justify-between items-center">
          <Button
            variant="outline"
            disabled={!tasks.length || currentPage === 1}
            onClick={() => setCurrentPage((prev) => prev - 1)}
          >
            Previous
          </Button>
          <span>
            Page {currentPage} of {totalPages}
          </span>
          <Button
            variant="outline"
            disabled={!tasks.length || currentPage === totalPages}
            onClick={() => setCurrentPage((prev) => prev + 1)}
          >
            Next
          </Button>
        </CardFooter>
      </Card>
    </div>
  );
}

export default App;

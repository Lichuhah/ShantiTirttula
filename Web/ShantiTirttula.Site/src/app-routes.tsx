import { HomePage, ProfilePage, ControllerPage, TriggerPage, TriggerFormPage, SensorsPage, SensorDataPage, DevicePage, CommandLogPage, SensorFormPage, 
ShedulesPage, SheduleTasksPage, CommandsPage, ShedulesFormPage, CommandsFormPage, SheduleTasksFormPage } from './pages';
import { withNavigationWatcher } from './contexts/navigation';

const routes = [
    {
        path: '/profile',
        element: ProfilePage
    },
    {
        path: '/home',
        element: HomePage
    },
    {
        path: '/controllers',
        element: ControllerPage
    },
    {
        path: '/triggers',
        element: TriggerPage
    },
    {
        path: '/triggers/form',
        element: TriggerFormPage
    },
    {
        path: '/sensors',
        element: SensorsPage
    },
    {
        path: '/sensordata',
        element: SensorDataPage
    },
    {
        path: '/devices',
        element: DevicePage
    },
    {
        path: '/commandlog',
        element: CommandLogPage
    },
    {
        path: '/sensors/form',
        element: SensorFormPage
    },
    {
        path: '/commands',
        element: CommandsPage
    },
    {
        path: '/commands/form',
        element: CommandsFormPage
    },
    {
        path: '/shedules',
        element: ShedulesPage
    },
    {
        path: '/shedules/form',
        element: ShedulesFormPage
    },
    {
        path: '/shedule-tasks',
        element: SheduleTasksPage
    },
    {
        path: '/shedule-tasks/form',
        element: SheduleTasksFormPage
    }
];

export default routes.map(route => {
    return {
        ...route,
        element: withNavigationWatcher(route.element, route.path)
    };
});

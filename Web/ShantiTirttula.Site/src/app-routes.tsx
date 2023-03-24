import { HomePage, ProfilePage, ControllerPage, TriggerPage, TriggerFormPage } from './pages';
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
    }
];

export default routes.map(route => {
    return {
        ...route,
        element: withNavigationWatcher(route.element, route.path)
    };
});

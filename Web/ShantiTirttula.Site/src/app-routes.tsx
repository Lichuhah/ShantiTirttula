import { HomePage, ProfilePage, ControllerPage, TriggerPage } from './pages';
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
    }
];

export default routes.map(route => {
    return {
        ...route,
        element: withNavigationWatcher(route.element, route.path)
    };
});

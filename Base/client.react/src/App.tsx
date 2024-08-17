import './assets/styles/App.css'
import { Route, Routes } from 'react-router-dom';
import {BasicLayout} from "./layouts/BasicLayout.tsx";
import {MainPage} from "./views/pages/MainPage.tsx";
import {ThemeProvider} from "@/components/theme-provider.tsx";

function App() {
    return (
        <>
            <ThemeProvider defaultTheme="dark" storageKey="vite-ui-theme">
                <Routes>
                    <Route path='/' element={<BasicLayout/>}>
                        <Route index element={<MainPage/>}/>
                    </Route>
                </Routes>
            </ThemeProvider>
        </>
    )
}

export default App

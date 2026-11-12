import type { ReactNode } from 'react'
import logo from '../assets/Möbelo-logo.png'

type StoreLayoutProps = {
  children: ReactNode
}

export default function StoreLayout({ children }: StoreLayoutProps) {
  return (
    <>
        <header className="store-header">
          <div className="store-header-inner">
            <a className="store-brand" href="/">
            
                <img src={logo} alt = "Möbelo" width={120}/>
            
            </a>
          </div>
        </header>

      <main className="store-main">{children}</main>

      <footer className="store-footer">
      
        <img src={logo} alt = "Möbelo" width={120}/>
      
      </footer>
    </>
  )
}
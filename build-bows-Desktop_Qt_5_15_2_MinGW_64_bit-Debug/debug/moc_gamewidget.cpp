/****************************************************************************
** Meta object code from reading C++ file 'gamewidget.h'
**
** Created by: The Qt Meta Object Compiler version 67 (Qt 5.15.2)
**
** WARNING! All changes made in this file will be lost!
*****************************************************************************/

#include <memory>
#include "../../b/gamewidget.h"
#include <QtCore/qbytearray.h>
#include <QtCore/qmetatype.h>
#if !defined(Q_MOC_OUTPUT_REVISION)
#error "The header file 'gamewidget.h' doesn't include <QObject>."
#elif Q_MOC_OUTPUT_REVISION != 67
#error "This file was generated using the moc from 5.15.2. It"
#error "cannot be used with the include files from this version of Qt."
#error "(The moc has changed too much.)"
#endif

QT_BEGIN_MOC_NAMESPACE
QT_WARNING_PUSH
QT_WARNING_DISABLE_DEPRECATED
struct qt_meta_stringdata_GameWidget_t {
    QByteArrayData data[16];
    char stringdata0[149];
};
#define QT_MOC_LITERAL(idx, ofs, len) \
    Q_STATIC_BYTE_ARRAY_DATA_HEADER_INITIALIZER_WITH_OFFSET(len, \
    qptrdiff(offsetof(qt_meta_stringdata_GameWidget_t, stringdata0) + ofs \
        - idx * sizeof(QByteArrayData)) \
    )
static const qt_meta_stringdata_GameWidget_t qt_meta_stringdata_GameWidget = {
    {
QT_MOC_LITERAL(0, 0, 10), // "GameWidget"
QT_MOC_LITERAL(1, 11, 9), // "gameStart"
QT_MOC_LITERAL(2, 21, 0), // ""
QT_MOC_LITERAL(3, 22, 8), // "gameStop"
QT_MOC_LITERAL(4, 31, 8), // "makeMove"
QT_MOC_LITERAL(5, 40, 16), // "calcBullsAndCows"
QT_MOC_LITERAL(6, 57, 5), // "input"
QT_MOC_LITERAL(7, 63, 8), // "original"
QT_MOC_LITERAL(8, 72, 4), // "int&"
QT_MOC_LITERAL(9, 77, 5), // "nCows"
QT_MOC_LITERAL(10, 83, 6), // "nBulls"
QT_MOC_LITERAL(11, 90, 16), // "readPersonNumber"
QT_MOC_LITERAL(12, 107, 13), // "isValidNumber"
QT_MOC_LITERAL(13, 121, 6), // "number"
QT_MOC_LITERAL(14, 128, 7), // "sNumber"
QT_MOC_LITERAL(15, 136, 12) // "computerMove"

    },
    "GameWidget\0gameStart\0\0gameStop\0makeMove\0"
    "calcBullsAndCows\0input\0original\0int&\0"
    "nCows\0nBulls\0readPersonNumber\0"
    "isValidNumber\0number\0sNumber\0computerMove"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_GameWidget[] = {

 // content:
       8,       // revision
       0,       // classname
       0,    0, // classinfo
       7,   14, // methods
       0,    0, // properties
       0,    0, // enums/sets
       0,    0, // constructors
       0,       // flags
       0,       // signalCount

 // slots: name, argc, parameters, tag, flags
       1,    0,   49,    2, 0x08 /* Private */,
       3,    0,   50,    2, 0x08 /* Private */,
       4,    0,   51,    2, 0x08 /* Private */,
       5,    4,   52,    2, 0x08 /* Private */,
      11,    0,   61,    2, 0x08 /* Private */,
      12,    2,   62,    2, 0x08 /* Private */,
      15,    0,   67,    2, 0x08 /* Private */,

 // slots: parameters
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void, QMetaType::QString, QMetaType::QString, 0x80000000 | 8, 0x80000000 | 8,    6,    7,    9,   10,
    QMetaType::Void,
    QMetaType::Bool, QMetaType::Int, QMetaType::QString,   13,   14,
    QMetaType::Void,

       0        // eod
};

void GameWidget::qt_static_metacall(QObject *_o, QMetaObject::Call _c, int _id, void **_a)
{
    if (_c == QMetaObject::InvokeMetaMethod) {
        auto *_t = static_cast<GameWidget *>(_o);
        Q_UNUSED(_t)
        switch (_id) {
        case 0: _t->gameStart(); break;
        case 1: _t->gameStop(); break;
        case 2: _t->makeMove(); break;
        case 3: _t->calcBullsAndCows((*reinterpret_cast< QString(*)>(_a[1])),(*reinterpret_cast< QString(*)>(_a[2])),(*reinterpret_cast< int(*)>(_a[3])),(*reinterpret_cast< int(*)>(_a[4]))); break;
        case 4: _t->readPersonNumber(); break;
        case 5: { bool _r = _t->isValidNumber((*reinterpret_cast< int(*)>(_a[1])),(*reinterpret_cast< QString(*)>(_a[2])));
            if (_a[0]) *reinterpret_cast< bool*>(_a[0]) = std::move(_r); }  break;
        case 6: _t->computerMove(); break;
        default: ;
        }
    }
}

QT_INIT_METAOBJECT const QMetaObject GameWidget::staticMetaObject = { {
    QMetaObject::SuperData::link<QWidget::staticMetaObject>(),
    qt_meta_stringdata_GameWidget.data,
    qt_meta_data_GameWidget,
    qt_static_metacall,
    nullptr,
    nullptr
} };


const QMetaObject *GameWidget::metaObject() const
{
    return QObject::d_ptr->metaObject ? QObject::d_ptr->dynamicMetaObject() : &staticMetaObject;
}

void *GameWidget::qt_metacast(const char *_clname)
{
    if (!_clname) return nullptr;
    if (!strcmp(_clname, qt_meta_stringdata_GameWidget.stringdata0))
        return static_cast<void*>(this);
    return QWidget::qt_metacast(_clname);
}

int GameWidget::qt_metacall(QMetaObject::Call _c, int _id, void **_a)
{
    _id = QWidget::qt_metacall(_c, _id, _a);
    if (_id < 0)
        return _id;
    if (_c == QMetaObject::InvokeMetaMethod) {
        if (_id < 7)
            qt_static_metacall(this, _c, _id, _a);
        _id -= 7;
    } else if (_c == QMetaObject::RegisterMethodArgumentMetaType) {
        if (_id < 7)
            *reinterpret_cast<int*>(_a[0]) = -1;
        _id -= 7;
    }
    return _id;
}
QT_WARNING_POP
QT_END_MOC_NAMESPACE
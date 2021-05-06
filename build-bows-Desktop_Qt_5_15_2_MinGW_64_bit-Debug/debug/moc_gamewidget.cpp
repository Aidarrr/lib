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
    QByteArrayData data[23];
    char stringdata0[272];
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
QT_MOC_LITERAL(15, 136, 12), // "computerMove"
QT_MOC_LITERAL(16, 149, 31), // "getRandomNumberWithUniqueDigits"
QT_MOC_LITERAL(17, 181, 14), // "isCharRepeated"
QT_MOC_LITERAL(18, 196, 9), // "charDigit"
QT_MOC_LITERAL(19, 206, 19), // "initializeCompArray"
QT_MOC_LITERAL(20, 226, 18), // "isConvenientNumber"
QT_MOC_LITERAL(21, 245, 11), // "guessNumber"
QT_MOC_LITERAL(22, 257, 14) // "currentMoveNum"

    },
    "GameWidget\0gameStart\0\0gameStop\0makeMove\0"
    "calcBullsAndCows\0input\0original\0int&\0"
    "nCows\0nBulls\0readPersonNumber\0"
    "isValidNumber\0number\0sNumber\0computerMove\0"
    "getRandomNumberWithUniqueDigits\0"
    "isCharRepeated\0charDigit\0initializeCompArray\0"
    "isConvenientNumber\0guessNumber\0"
    "currentMoveNum"
};
#undef QT_MOC_LITERAL

static const uint qt_meta_data_GameWidget[] = {

 // content:
       8,       // revision
       0,       // classname
       0,    0, // classinfo
      11,   14, // methods
       0,    0, // properties
       0,    0, // enums/sets
       0,    0, // constructors
       0,       // flags
       0,       // signalCount

 // slots: name, argc, parameters, tag, flags
       1,    0,   69,    2, 0x08 /* Private */,
       3,    0,   70,    2, 0x08 /* Private */,
       4,    0,   71,    2, 0x08 /* Private */,
       5,    4,   72,    2, 0x08 /* Private */,
      11,    0,   81,    2, 0x08 /* Private */,
      12,    2,   82,    2, 0x08 /* Private */,
      15,    0,   87,    2, 0x08 /* Private */,
      16,    0,   88,    2, 0x08 /* Private */,
      17,    2,   89,    2, 0x08 /* Private */,
      19,    0,   94,    2, 0x08 /* Private */,
      20,    4,   95,    2, 0x08 /* Private */,

 // slots: parameters
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void,
    QMetaType::Void, QMetaType::QString, QMetaType::QString, 0x80000000 | 8, 0x80000000 | 8,    6,    7,    9,   10,
    QMetaType::Void,
    QMetaType::Bool, QMetaType::Int, QMetaType::QString,   13,   14,
    QMetaType::Void,
    QMetaType::QString,
    QMetaType::Bool, QMetaType::QString, QMetaType::QChar,   14,   18,
    QMetaType::Void,
    QMetaType::Bool, QMetaType::QString, QMetaType::QString, QMetaType::Int, QMetaType::Int,   21,   22,    9,   10,

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
        case 7: { QString _r = _t->getRandomNumberWithUniqueDigits();
            if (_a[0]) *reinterpret_cast< QString*>(_a[0]) = std::move(_r); }  break;
        case 8: { bool _r = _t->isCharRepeated((*reinterpret_cast< QString(*)>(_a[1])),(*reinterpret_cast< QChar(*)>(_a[2])));
            if (_a[0]) *reinterpret_cast< bool*>(_a[0]) = std::move(_r); }  break;
        case 9: _t->initializeCompArray(); break;
        case 10: { bool _r = _t->isConvenientNumber((*reinterpret_cast< QString(*)>(_a[1])),(*reinterpret_cast< QString(*)>(_a[2])),(*reinterpret_cast< int(*)>(_a[3])),(*reinterpret_cast< int(*)>(_a[4])));
            if (_a[0]) *reinterpret_cast< bool*>(_a[0]) = std::move(_r); }  break;
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
        if (_id < 11)
            qt_static_metacall(this, _c, _id, _a);
        _id -= 11;
    } else if (_c == QMetaObject::RegisterMethodArgumentMetaType) {
        if (_id < 11)
            *reinterpret_cast<int*>(_a[0]) = -1;
        _id -= 11;
    }
    return _id;
}
QT_WARNING_POP
QT_END_MOC_NAMESPACE
